using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Variables.Definitions
{
    [CreateAssetMenu]
    public class IntVariable : Variable<int>
    {

    }

    [CustomEditor(typeof(IntVariable))]
    public class IntVariableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            IntVariable myScript = (IntVariable)target;
            if (GUILayout.Button("Invoke"))
            {
                myScript.ValueChangedEvent.Invoke();
            }
        }
    }
}