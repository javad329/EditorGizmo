using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GizmoStruct {
    public Vector3 Sphere;
    public string label;
}


public class CustomEditor : EditorWindow
{
    string Spawn = "Spawn";
    string PNJtoHelp= "PNJ to Help";
    string BossArena= "Boss Arena";
    string EndLevel= "End Level";
    string FirstFight= "First Fight";
    public Vector3[] DefultPositions= new Vector3[5];
    public Vector3[] GizmoSphere =new Vector3[5];
    public Vector3[] SphereEditor = new Vector3[5];
    public GizmoStruct[] Gizmo = new GizmoStruct[5];
    //public Stack<GizmoStruct> Gizmo = new Stack<GizmoStruct>();
    //private int[] controlIds;
    int id = 0;
    string EditBtn = "Edit";
    bool FirstRun = true;
    Rect newRect;
    int x = 0;
    public int Selected=0;
    [MenuItem("Window/Custom/Editor Gizmos")]
    public static CustomEditor CustomEd()
    {
        return EditorWindow.GetWindow<CustomEditor>("Custom Editor");
    }
    void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
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
    void OnGUI()
    {
        GUILayout.Label("Gizmo Editor", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal("box");

        EditorGUILayout.LabelField("Text");
        EditorGUILayout.LabelField("Position");

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");
        Spawn = EditorGUILayout.TextField(Spawn, EditorStyles.miniTextField);
        x=EditorGUILayout.IntField("X", x);
        SphereEditor[0].y=EditorGUILayout.IntField("Y", (int)SphereEditor[0].y);
        SphereEditor[0].z=EditorGUILayout.IntField("Z", (int)SphereEditor[0].z);
        if (GUILayout.Button(EditBtn))
        {
            Gizmo[0].label= Spawn;
            Gizmo[0].Sphere= SphereEditor[0];
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");
        EndLevel = EditorGUILayout.TextField(EndLevel, EditorStyles.miniTextField);
        SphereEditor[1].x=EditorGUILayout.IntField("X", (int)SphereEditor[1].x);
        SphereEditor[1].y=EditorGUILayout.IntField("Y", (int)SphereEditor[1].y);
        SphereEditor[1].z=EditorGUILayout.IntField("Z", (int)SphereEditor[1].z);
        if (GUILayout.Button(EditBtn))
        {
            Gizmo[1].label = EndLevel;
            Gizmo[1].Sphere = SphereEditor[1];
        }
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal("box");
        FirstFight = EditorGUILayout.TextField(FirstFight, EditorStyles.miniTextField);
        SphereEditor[2].x=EditorGUILayout.IntField("X", (int)SphereEditor[2].x);
        SphereEditor[2].y=EditorGUILayout.IntField("Y", (int)SphereEditor[2].y);
        SphereEditor[2].z=EditorGUILayout.IntField("Z", (int)SphereEditor[2].z);
        if (GUILayout.Button(EditBtn))
        {
            Gizmo[2].label = FirstFight;
            Gizmo[2].Sphere = SphereEditor[2];
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");
        PNJtoHelp=EditorGUILayout.TextField(PNJtoHelp, EditorStyles.miniTextField);
        SphereEditor[3].x=EditorGUILayout.IntField("X", (int)SphereEditor[3].x);
        SphereEditor[3].y=EditorGUILayout.IntField("Y", (int)SphereEditor[3].y);
        SphereEditor[3].z=EditorGUILayout.IntField("Z", (int)SphereEditor[3].z);
        if (GUILayout.Button(EditBtn))
        {
            Gizmo[3].label = PNJtoHelp;
            Gizmo[3].Sphere = SphereEditor[3];
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");
        BossArena=EditorGUILayout.TextField(BossArena, EditorStyles.miniTextField);
        SphereEditor[4].x=EditorGUILayout.IntField("X", (int)SphereEditor[4].x);
        SphereEditor[4].y=EditorGUILayout.IntField("Y", (int)SphereEditor[4].y);
        SphereEditor[4].z=EditorGUILayout.IntField("Z", (int)SphereEditor[4].z);
        if (GUILayout.Button(EditBtn))
        {
            Gizmo[4].label = BossArena;
            Gizmo[4].Sphere = SphereEditor[4];
        }
        GUILayout.EndHorizontal();
        
    }
    void OnSceneGUI(SceneView sv)
    {

        if (FirstRun)
        {
            for (int i = 0; i < 5; i++)
            {
                Gizmo[i] = new GizmoStruct();
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
        //Draw your handles here
        Handles.color = Color.black;
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.black;
        Vector3 LablePos=new Vector3(0,0,0);
        for (int i = 0; i < 5; i++)
        {
            LablePos = Gizmo[i].Sphere;
            LablePos.y=LablePos.y + 1;
            Handles.Label(LablePos, Gizmo[i].label, style);
        }
        Handles.color = Color.white;

        //https://forum.unity.com/threads/currently-selected-handle-in-editor-script.87634/
        for (int i = 0; i < 5; i++)
        {
            Vector3 NewPos = Gizmo[i].Sphere;
            NewPos = Handles.FreeMoveHandle(NewPos, Quaternion.identity, 3f, Vector3.zero, (controlID, position, rotation, size) =>
            {
                id = controlID;
                //Handles.RectangleCap(controlID, position, rotation, size);
                HandleFunc(controlID, position, rotation, size);
            });
            if (NewPos != Gizmo[i].Sphere)
            {
                Gizmo[i].Sphere = NewPos;
                SphereEditor[i] = NewPos;
            }
        }
        Event e = Event.current;//https://docs.unity3d.com/ScriptReference/Event-button.html
        if (e.button == 1 && e.isMouse )//&& GizmoSelected)
        {
           
            for(int i=0; i<5;i++)
            {
                
                Vector3 ScenPos= HandleUtility.WorldToGUIPointWithDepth(Gizmo[i].Sphere);
                float Dist=Vector2.Distance(new Vector2(ScenPos.x, ScenPos.y), e.mousePosition);
                if (Dist<10)
                {
                    // Now create the menu, add items and show it
                    Selected = i;
                    GenericMenu menu = new GenericMenu();
                    menu.AddItem(new GUIContent("Reset Position"), false, Callback , "item 1");// {  }
                    menu.AddItem(new GUIContent("Delete Gizmo"), false, Callback, "item 2");
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
            //GizmoSelected = true;
        }
        else
        {
            //GizmoSelected = false;
            GUI.color = Color.green;
        }
           
        //Handles.Label(position, new GUIContent(nodeTexture), m_handleStyle);
        Handles.SphereHandleCap(controlID, position, Quaternion.identity, 1f, EventType.Repaint);
        /*Rect myRect = new Rect(position, new Vector2(1, 1));
        Handles.RectangleHandleCap(controlID, position, rotation, size, EventType.Repaint);
        try
        {
            Rects.Add(controlID, myRect);
            
            //EditorGUI.DrawRect(GUILayoutUtility.GetLastRect(), Color.blue);

        }
        catch (System.Exception e)
        {
            int a = 0;
        }*/
      
        GUI.color = Color.white;
    }
    public void newfunc()
    { }
}
/*if (Event.current.type == EventType.MouseDown)
{
   int a = 0;
}[
if (GUI.changed)
{
    int f = GUIUtility.hotControl;
}*/