using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Variables.Definitions
{
    [CreateAssetMenu]
    public class IntVariable : Variable<int>
    {

    }

#if UNITY_EDITOR
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
#endif
}