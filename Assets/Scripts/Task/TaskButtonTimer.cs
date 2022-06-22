using UnityEngine;
using UnityEngine.UI;
using System;

namespace Clicker.GameLogic
{
    [RequireComponent(typeof(Button))]
    public sealed class TaskButtonTimer : Timer
    {
        public event Action OnReseted;
        [SerializeField] private AudioSource _openSound;
        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        public void ResetTimer()
        {
            OnReseted.Invoke();
            StartCoroutine(Enable());
        }

        protected override void PlayStartFeedback()
        {
            _openSound.Play();
            _button.interactable = false;
        }

        protected override void PlayEndFeedback()
        {
            _button.interactable = true;
        }
    }
}
