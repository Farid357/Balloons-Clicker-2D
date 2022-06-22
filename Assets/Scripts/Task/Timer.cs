using System;
using System.Collections;
using UnityEngine;

namespace Clicker.GameLogic
{
    public abstract class Timer : MonoBehaviour
    {
        public event Action<int> OnTicked;

        [SerializeField, Min(1)] private int _time = 3;
        private WaitForSeconds _wait;

        public int StartTime { get; private set; }

        private void Start()
        {
            StartTime = _time;
            _wait = new WaitForSeconds(1);
            OnTicked.Invoke(_time);
            StartCoroutine(Enable());
        }

        private void OnEnable()
        {
            if (_time < StartTime)
                _time = StartTime;
        }

        protected IEnumerator Enable()
        {
            PlayStartFeedback();
            while (_time >= 0)
            {
                OnTicked.Invoke(_time);
                yield return _wait;
                _time--;
            }
            PlayEndFeedback();
        }
        protected abstract void PlayStartFeedback();
        protected abstract void PlayEndFeedback();
    }
}
