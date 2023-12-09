using UnityEngine;

using UnityEditor;
using UdonSharpEditor;

namespace sh0uRoom.VRCSIL
{
    [CustomEditor(typeof(ImageURLInputter))]
    public class ImageURLInputterEditor : Editor
    {
        private SerializedProperty urlInput;
        private SerializedProperty messageTextUI;

        public override void OnInspectorGUI()
        {
            if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;

            serializedObject.Update();

            GetProperties();
            ShowBaseGUI();

            serializedObject.ApplyModifiedProperties();
        }

        private void GetProperties()
        {
            urlInput = serializedObject.FindProperty("urlInput");
            messageTextUI = serializedObject.FindProperty("messageTextUI");
        }

        private void ShowBaseGUI()
        {
            EditorGUILayout.HelpBox("動作にはImageLoaderが必要です", MessageType.Info, true);

            EditorGUILayout.PropertyField(urlInput, new GUIContent("入力フォームUI"));
            EditorGUILayout.PropertyField(messageTextUI, new GUIContent("メッセージ出力先UI"));
        }
    }
}
