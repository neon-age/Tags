using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class EditorGizmosUtility
{
    private static readonly MethodInfo getAnnotations;
    private static readonly MethodInfo setGizmoEnabled;
    private static readonly MethodInfo setIconEnabled;
    private static readonly IEnumerable annotations;

    static EditorGizmosUtility()
    {
        var utilityType = typeof(Editor).Assembly.GetType("UnityEditor.AnnotationUtility");

        getAnnotations = utilityType.GetMethod("GetAnnotations", BindingFlags.Static | BindingFlags.NonPublic);
        setGizmoEnabled = utilityType.GetMethod("SetGizmoEnabled", BindingFlags.Static | BindingFlags.NonPublic);
        setIconEnabled = utilityType.GetMethod("SetIconEnabled", BindingFlags.Static | BindingFlags.NonPublic);
        
        annotations = (IEnumerable)getAnnotations.Invoke(null, null);
    }

    public static void ToggleGizmos(Type componentType, bool on)
    {
        var componentTypeName = componentType.Name;
        var annotationType = typeof(Editor).Assembly.GetType("UnityEditor.Annotation");
        var classIdField = annotationType.GetField("classID", BindingFlags.Public | BindingFlags.Instance);
        var scriptClassField = annotationType.GetField("scriptClass", BindingFlags.Public | BindingFlags.Instance);
        
        foreach (var annotation in annotations)
        {
            var classId = (int)classIdField.GetValue(annotation);
            var scriptClass = (string)scriptClassField.GetValue(annotation);

            if (scriptClass != componentTypeName)
                continue;
                
            setGizmoEnabled.Invoke(null, new object[] { classId, scriptClass, on ? 1 : 0, true });
            setIconEnabled.Invoke(null, new object[] { classId, scriptClass, on ? 1 : 0 });
        }
    }
}
