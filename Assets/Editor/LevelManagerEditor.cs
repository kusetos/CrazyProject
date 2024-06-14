using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelDataManager))]
public class LevelManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var script = (LevelDataManager)target;
        if (GUILayout.Button("Save Level"))
        {
            script.SaveLevel();
        }
        if (GUILayout.Button("Clear Level"))
        {
            script.ClearLevel();
        }
        if(GUILayout.Button("Load Level"))
        {
            script.LoadLevel();
        }

    }

}
