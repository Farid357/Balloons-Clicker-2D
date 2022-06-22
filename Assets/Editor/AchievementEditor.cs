using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;
using Clicker.GameLogic;

namespace Clicker.Editor
{
    [System.Serializable]
    public sealed class AchievementEditor : EditorWindow
    {
        private AchievementView _prefab;
        private Transform _parent;
        private readonly StyleCreator _style = new();
        private GUIStyle _labelStyle;
        private GUIStyle _textStyle;
        private string _text;
        private AchievementType _type;
        private int _coinsCount;
        private int _applyCount;

        [MenuItem("Window/Achievement editor")]
        public static void Create()
        {
            var window = GetWindow<AchievementEditor>();
            window.Show();
        }

        private void OnGUI()
        {
            SetStyles();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(30);
            EditorGUILayout.LabelField("Создание достижений", _labelStyle);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Префаб", _textStyle);
            _prefab = (AchievementView)EditorGUILayout.ObjectField(_prefab, typeof(AchievementView), false);
            EditorGUILayout.Space(30);
            EditorGUILayout.LabelField("Родитель", _textStyle);
            _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);
            EditorGUILayout.Space(15);
            EditorGUILayout.LabelField("Текст", _textStyle);
            _text = EditorGUILayout.TextField(_text);
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Награда (очки)", _textStyle);
            EditorGUILayout.Space(15);
            _coinsCount = EditorGUILayout.IntField(_coinsCount);
            EditorGUILayout.LabelField("Нужное количество", _textStyle);
            EditorGUILayout.Space(20);
            _applyCount = EditorGUILayout.IntField(_applyCount);
            EditorGUILayout.Space(15);
            _type = (AchievementType)EditorGUILayout.EnumPopup("Тип", _type);
            EditorGUILayout.Space(20);

            if (GUILayout.Button("Создать"))
            {
                var achievement = Instantiate(_prefab, _parent);
                achievement.SetText(_text);
                var initializeAchievement = achievement.GetComponent<Achievement>();
                initializeAchievement.Constructor(_coinsCount, _type, _applyCount);
                SetDirty(initializeAchievement, "AchievementInit");
            }

            if (GUI.changed)
            {
                SetDirty(this, "Modify");
            }
        }

        private void SetDirty<T>(T recordObject, string modify) where T : Object
        {
            Undo.RecordObject(recordObject, modify);
            EditorUtility.SetDirty(recordObject);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        private void SetStyles()
        {
            _labelStyle ??= _style.CreateLabelStyle();
            _textStyle ??= _style.CreateTextStyle();
        }
    }
}
