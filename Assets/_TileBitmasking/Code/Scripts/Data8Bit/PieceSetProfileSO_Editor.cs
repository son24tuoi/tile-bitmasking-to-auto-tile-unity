using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TileBitmasking.Data8Bit
{
    [CustomEditor(typeof(PieceSetProfileSO))]
    public class PieceSetProfileSO_Editor : Editor
    {
        private PieceSetProfileSO pieceSetProfile;

        private SerializedProperty tileSpriteyProperties;

        private void OnEnable()
        {
            pieceSetProfile = (PieceSetProfileSO)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            tileSpriteyProperties = serializedObject.FindProperty("value");
            EditorGUILayout.PropertyField(tileSpriteyProperties);
            EditorGUILayout.ObjectField(tileSpriteyProperties, typeof(Sprite), new GUIContent("Test"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
