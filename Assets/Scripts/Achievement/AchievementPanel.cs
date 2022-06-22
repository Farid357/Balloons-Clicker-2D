using System.Collections;
using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class AchievementPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        private float _delay = 1.5f;
        private WaitForSeconds _wait;
        private bool _isStarted;

        public void StartShowing() => StartCoroutine(Show());

        private IEnumerator Show()
        {
            _delay = TryIncreaseDelay(_delay);
            _isStarted = true;
            _wait = new WaitForSeconds(_delay);
            _panel.SetActive(true);
            yield return _wait;
            _isStarted = false;
            _panel.SetActive(false);
        }

        private float TryIncreaseDelay(float delay)
        {
            if (_isStarted)
            {
                delay += _delay;
                return delay;
            }
            return _delay;
        }
    }
}
