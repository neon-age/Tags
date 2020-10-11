#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(Tags))]
[CanEditMultipleObjects]
internal class TagsEditor : Editor
{
    private SerializedProperty tagsProperty;
    private ReorderableList tagsList;

    [InitializeOnLoadMethod]
    private static void DisableGizmo()
    {
        EditorGizmosUtility.ToggleGizmos(typeof(Tags), false);
    }

    private void OnEnable()
    {
        tagsProperty = serializedObject.FindProperty("tags");

        tagsList = new ReorderableList(serializedObject, tagsProperty)
        {
            headerHeight = 0
        };

        tagsList.drawElementCallback += (rect, index, active, focused) =>
        {
	        rect.height = EditorGUIUtility.singleLineHeight;
	        rect.y += EditorGUIUtility.standardVerticalSpacing / 2;

            var tag = tagsProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(rect, tag, GUIContent.none);
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.Space(-5);
        tagsList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
