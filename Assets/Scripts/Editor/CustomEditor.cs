using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GizmoStruct {
    public Vector3 Sphere;
    public string label;
}

[CreateAssetMenu(fileName = "Gizmo Asset", menuName = "Custom/Create Gizmo Asset")]
public class CustomEditor : EditorWindow
{

    public Vector3[] DefultPositions= new Vector3[5];
    public Vector3[] GizmoSphere =new Vector3[5];
    public Vector3[] SphereEditor = new Vector3[5];
    public List<GizmoStruct> Gizmo = new List<GizmoStruct>();

    string EditBtn = "Edit";
    bool FirstRun = true;
    
    int x = 0;
    public int Selected=0;
    public int RemSelected = 0;
    [MenuItem("Window/Custom/Editor Gizmos")]
    public static CustomEditor CustomEd()
    {
        return EditorWindow.GetWindow<CustomEditor>("Custom Editor");
    }

    void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
        CustomEditor myWindow = (CustomEditor)EditorWindow.GetWindow(typeof(CustomEditor));
        myWindow.autoRepaintOnSceneChange = true;
        EditorApplication.modifierKeysChanged += myWindow.Repaint;
    }

    void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

   
   
    public void Callback(object obj)
    {
        Gizmo[Selected].Sphere = DefultPositions[Selected];
        SphereEditor[Selected] = DefultPositions[Selected];
    }
    public void Callback2(object obj)
    {
        Gizmo.RemoveAt(RemSelected);
        
    }
    void OnGUI()
    {
       
        GUILayout.Label("Gizmo Editor", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal("box");

        EditorGUILayout.LabelField("Text");
        EditorGUILayout.LabelField("Position");

        GUILayout.EndHorizontal();
        EditorGUI.BeginChangeCheck();
        for (int i = 0; i < Gizmo.Count; i++)
        {
            
            GUILayout.BeginHorizontal("box");
            Gizmo[i].label = EditorGUILayout.TextField(Gizmo[i].label, EditorStyles.miniTextField);
            SphereEditor[i].x = EditorGUILayout.IntField("X", (int)SphereEditor[i].x);
            SphereEditor[i].y = EditorGUILayout.IntField("Y", (int)SphereEditor[i].y);
            SphereEditor[i].z = EditorGUILayout.IntField("Z", (int)SphereEditor[i].z);
            if (GUILayout.Button(EditBtn))
            {
                Gizmo[i].label = Gizmo[i].label;
                Gizmo[i].Sphere = SphereEditor[i];
            }
            GUILayout.EndHorizontal();
        }
       
        if (EditorGUI.EndChangeCheck())
        {
            //Undo.RecordObject((Object)Gizmo, "Changed Area Of Effect");
            
        }





    }
    void OnSceneGUI(SceneView sv)
    {
       // CustomEditor t = (Editor.target as CustomEditor);

        if (FirstRun)
        {
            for (int i = 0; i < 5; i++)
            {
                Gizmo.Add(  new GizmoStruct());
                SphereEditor[i] = new Vector3();
                //Rects[i]= new RectStruct();
            }
            Gizmo[0].Sphere = new Vector3(0, 0, 0);
            Gizmo[1].Sphere = new Vector3(100, 25, 100);
            Gizmo[2].Sphere = new Vector3(20, 20, 10);
            Gizmo[3].Sphere = new Vector3(67, 48, 59);
            Gizmo[4].Sphere = new Vector3(80, 20, 75);

            Gizmo[0].label = "Spawn";
            Gizmo[1].label = "End Level";
            Gizmo[2].label = "First Fight";
            Gizmo[3].label = "PNJ to Help";
            Gizmo[4].label = "Boss Arena";

            SphereEditor[0] = new Vector3(0, 0, 0);
            SphereEditor[1] = new Vector3(100, 25, 100);
            SphereEditor[2] = new Vector3(20, 20, 10);
            SphereEditor[3] = new Vector3(67, 48, 59);
            SphereEditor[4] = new Vector3(80, 20, 75);

            
            DefultPositions[0] = new Vector3(0, 0, 0);
            DefultPositions[1] = new Vector3(100, 25, 100);
            DefultPositions[2] = new Vector3(20, 20, 10);
            DefultPositions[3] = new Vector3(67, 48, 59);
            DefultPositions[4] = new Vector3(80, 20, 75);
            FirstRun = false;
        }
        
        Handles.color = Color.black;
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.black;
        Vector3 LablePos=new Vector3(0,0,0);
        for (int i = 0; i < Gizmo.Count; i++)
        {
            LablePos = Gizmo[i].Sphere;
            LablePos.y=LablePos.y + 1;
            Handles.Label(LablePos, Gizmo[i].label, style);
        }
        Handles.color = Color.white;

        //https://forum.unity.com/threads/currently-selected-handle-in-editor-script.87634/
        for (int i = 0; i < Gizmo.Count; i++)
        {
            Vector3 NewPos = Gizmo[i].Sphere;
            NewPos = Handles.FreeMoveHandle(NewPos, Quaternion.identity, 3f, Vector3.zero, (controlID, position, rotation, size) =>
            {
             
                
                HandleFunc(controlID, position, rotation, size);
            });
            if (NewPos != Gizmo[i].Sphere)
            {
                Gizmo[i].Sphere = NewPos;
                SphereEditor[i] = NewPos;
            }
        }
        Event e = Event.current;//https://docs.unity3d.com/ScriptReference/Event-button.html
        if (e.button == 1 && e.isMouse )
        {
           
            for(int i=0; i<Gizmo.Count;i++)
            {
                
                Vector3 ScenPos= HandleUtility.WorldToGUIPointWithDepth(Gizmo[i].Sphere);
                float Dist=Vector2.Distance(new Vector2(ScenPos.x, ScenPos.y), e.mousePosition);
                if (Dist<10)
                {
                    // Now create the menu, add items and show it
                    Selected = i;
                    RemSelected = i;
                    GenericMenu menu = new GenericMenu();
                    menu.AddItem(new GUIContent("Reset Position"), false, Callback , "item 1");// {  }
                    menu.AddItem(new GUIContent("Delete Gizmo"), false, Callback2, "item 2");
                    menu.ShowAsContext();

                }
            }
           
            Debug.Log("Right Click");
           

           
            
        }
    }
    void HandleFunc(int controlID, Vector3 position, Quaternion rotation, float size)
    {

        
        if (controlID == GUIUtility.hotControl)
        {
            GUI.color = Color.red;
            Handles.PositionHandle(position, Quaternion.identity);
          
        }
        else
        {
            GUI.color = Color.green;
        }
           
       
        Handles.SphereHandleCap(controlID, position, Quaternion.identity, 1f, EventType.Repaint);
       
      
        GUI.color = Color.white;
    }

}
