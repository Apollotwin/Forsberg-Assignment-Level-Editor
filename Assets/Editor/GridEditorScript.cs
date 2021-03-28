using UnityEngine;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(Grid))]
    public class GridEditorScript : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var t = target as Grid;
            base.OnInspectorGUI();
            GUILayout.Space(10);
            if (GUILayout.Button("Populate grid"))
            {
                t.PopulateGrid();
            }
        }
    }
}
