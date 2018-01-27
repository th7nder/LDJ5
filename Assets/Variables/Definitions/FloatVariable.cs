using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Variables.Definitions
{
    [CreateAssetMenu]
    public class FloatVariable : Variable<float>
    {

    }

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
}