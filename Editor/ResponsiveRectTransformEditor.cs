using System;
using UnityEditor;
using UnityEngine;

namespace SpellBoundAR.LayoutGroups.Editor
{
    [CustomEditor(typeof(ResponsiveRectTransform))]
    public class ResponsiveRectTransformEditor : UnityEditor.Editor
    {
        private ResponsiveRectTransform _responsiveRectTransformEditor;

        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Control Width", GUILayout.MaxWidth(90));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("setWidth"), GUIContent.none, GUILayout.MaxWidth(25));
            if (serializedObject.FindProperty("setWidth").boolValue)
            {
                GUILayout.Label("Screen Percent", GUILayout.MaxWidth(100));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("screenWidthPercent"), GUIContent.none);
            }
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Control Height", GUILayout.MaxWidth(90));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("setHeight"), GUIContent.none, GUILayout.MaxWidth(25));
            if (serializedObject.FindProperty("setHeight").boolValue)
            {
                GUILayout.Label("Screen Percent", GUILayout.MaxWidth(100));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("screenHeightPercent"), GUIContent.none);
            }
            GUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
