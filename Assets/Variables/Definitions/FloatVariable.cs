﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Variables.Definitions
{
    [CreateAssetMenu]
    public class FloatVariable : Variable<float>
    {

    }

    #if UNITY_EDITOR
    [CustomEditor(typeof(FloatVariable))]

    public class FloatVariableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            FloatVariable myScript = (FloatVariable)target;
            if (GUILayout.Button("Invoke"))
            {
                myScript.ValueChangedEvent.Invoke();
            }
        }
    }

    #endif
}