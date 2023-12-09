using UnityEngine;

using UnityEditor;
using UdonSharpEditor;

namespace sh0uRoom.VRCSIL
{
    [CustomEditor(typeof(ImageLoader))]
    public class ImageLoaderEditor : Editor
    {
        private SerializedProperty targetUrl;
        private SerializedProperty material;
        private SerializedProperty isLoadOnStart;
        private SerializedProperty inputter;

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
            targetUrl = serializedObject.FindProperty("targetUrl");
            material = serializedObject.FindProperty("material");
            isLoadOnStart = serializedObject.FindProperty("isLoadOnStart");
            inputter = serializedObject.FindProperty("inputter");
        }

        private void ShowBaseGUI()
        {
            EditorGUILayout.HelpBox("一部URLはユーザー側で\"Allow Untrasted URL\"を有効にする必要があります\n取得できる画像の種類・制限事項は右上のヘルプマーク(?)から確認できます", MessageType.Info, true);

            EditorGUILayout.PropertyField(targetUrl, new GUIContent("取得先URL"));
            EditorGUILayout.PropertyField(material, new GUIContent("出力先マテリアル"));
            EditorGUILayout.PropertyField(isLoadOnStart, new GUIContent("開始時自動ロード"));

            //オプションであることを記載する
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("オプション", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(inputter, new GUIContent("(op)状態出力スクリプト"));
        }
    }
}
