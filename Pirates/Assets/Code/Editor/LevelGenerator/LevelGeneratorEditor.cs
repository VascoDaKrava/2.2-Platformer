using UnityEditor;
using UnityEngine;


namespace PiratesGame
{
    [CustomEditor(typeof(LevelGeneratorView))]
    public sealed class LevelGeneratorEditor : Editor
    {

        #region Fields

        private LevelGeneratorController _controller;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _controller = new LevelGeneratorController((LevelGeneratorView)target);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (GUI.Button(new Rect(20, 10, 150, 30), "Generate level"))
            {
                _controller.GenerateLevel();
            }

            if (GUI.Button(new Rect(20, 50, 150, 30), "Clear level"))
            {
                _controller.ClearMap();
            }

            GUILayout.Space(80);

            serializedObject.ApplyModifiedPropertiesWithoutUndo();
        }

        #endregion

    }
}
