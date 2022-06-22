using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using Zenject;

namespace Clicker.GameLogic
{
    [RequireComponent(typeof(Achievement))]
    public sealed class AchievementView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _openImage;
        private Achievement _achievement;
        private AchievementPanel _panel;
        private bool _isOpen;

        [Inject]
        private void Init(AchievementPanel panel) => _panel = panel;

        private void Start()
        {
            _achievement = GetComponent<Achievement>();
            _achievement.OnClaimed += Show;
            _isOpen =  !_achievement.IsClosed;
            _openImage.gameObject.SetActive(_isOpen);
        }

        private void OnDestroy() => _achievement.OnClaimed -= Show;

        public void SetText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new NullReferenceException(nameof(text));
            _text.text = text;
        }

        public void Show()
        {
            _openImage.gameObject.SetActive(true);
            _panel.StartShowing();
        }
    }
}
