using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CostomEditor(typeof(StageLevelManager))]

public class StageLevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        StageLevelManager manager = target as StageLevelManager;

        GUILayout.Space(10);

        manager.editTilePrefab = EditorGUILayout.ObjectField("타일 프리펩", manager.editTilePrefab, typeof(GameObject)) as GameObject;

    }
    
}
