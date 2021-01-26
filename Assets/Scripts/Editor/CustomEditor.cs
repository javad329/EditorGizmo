using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomEditor : EditorWindow
{
    string Spawn = "Spawn";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    static int x = 0;
    static int y = 0;
    [MenuItem("Window/Custom/Editor Gizmos")]
    public static CustomEditor CustomEd()
    {
        return EditorWindow.GetWindow<CustomEditor>("Custom Editor");
    }
    void OnGUI()
    {
        GUILayout.Label("Gizmo Editor", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal("box");

        EditorGUILayout.LabelField("Text");
        EditorGUILayout.LabelField("Position");

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");
        EditorGUILayout.TextField("Spawn", EditorStyles.miniTextField);
        EditorGUILayout.PrefixLabel("X");
        EditorGUILayout.IntField(x);
        EditorGUILayout.PrefixLabel("Y");
        EditorGUILayout.IntField(y);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");
        EditorGUILayout.TextField("End Level", EditorStyles.miniTextField);
        EditorGUILayout.PrefixLabel("X");
        EditorGUILayout.IntField(x);
        EditorGUILayout.PrefixLabel("Y");
        EditorGUILayout.IntField(y);
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal("box");
        EditorGUILayout.TextField("First Fight", EditorStyles.miniTextField);
        EditorGUILayout.PrefixLabel("X");
        EditorGUILayout.IntField(x);
        EditorGUILayout.PrefixLabel("Y");
        EditorGUILayout.IntField(y);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");
        EditorGUILayout.TextField("PNJ to help", EditorStyles.miniTextField);
        EditorGUILayout.PrefixLabel("X");
        EditorGUILayout.IntField(x);
        EditorGUILayout.PrefixLabel("Y");
        EditorGUILayout.IntField(y);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");
        EditorGUILayout.TextField("Boss Arena", EditorStyles.miniTextField);
        EditorGUILayout.PrefixLabel("X");
        EditorGUILayout.IntField(x);
        EditorGUILayout.PrefixLabel("Y");
        EditorGUILayout.IntField(y);
        GUILayout.EndHorizontal();
      


        /*groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();*/
    }
}
