using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(Bricks)), CanEditMultipleObjects]

[ExecuteInEditMode]
public class BrickManager : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Bricks scripts = (Bricks)target;

        if (GUILayout.Button("Change Position"))
        {
            foreach (var script in targets.Cast<Bricks>())
            {
                script.ChangePosition();
            }
        }
    }
}
