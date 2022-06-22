using TMPro;
using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class AnswerTimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private AnswerTimer _timer;

        private void OnEnable() => _timer.OnTicked += Display;

        private void OnDisable() => _timer.OnTicked -= Display;

        private void Display(int time)
        {
            _timerText.text = time.ToString();
            TryChangeColor(time);
        }

        private void TryChangeColor(int time)
        {
            _timerText.text = time.ToString();
            if (time <= _timer.StartTime / 2)
                _timerText.color = Color.red;
        }
    }
}
