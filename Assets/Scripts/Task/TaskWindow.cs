using UnityEngine.UI;
using UnityEngine;
using Clicker.Tools;

namespace Clicker.GameLogic
{
    public sealed class TaskWindow : MonoBehaviour
    {
        public Image[] Signs => _signs;
        [SerializeField] private CoinsCollector _collector;
        [SerializeField] private TaskButtonTimer _task;
        [SerializeField] private TaskAudio _audio;
        [SerializeField] private Image[] _signs;
        [SerializeField] private GameObject _solvePanel;
        [SerializeField] private TaskBonus _bonus;
        private int _result;
        private string _answerText;

        public void SetResult(int result) => _result = result;

        public void SetAnswerText(string answerText) => _answerText = answerText;

        public void Show()
        {
            bool correct = CalculationSigns.CheckResult(_result, _answerText);
            _audio.Play(correct);
            _bonus.TryApply(correct);
            Invoke(nameof(DisablePanel), 1);
        }

        public void Disable()
        {
            for (int i = 0; i < _signs.Length; i++)
            {
                _signs[i].gameObject.SetActive(false);
            }
        }

        public void DisablePanel()
        {
            Disable();
            _task.ResetTimer();
            _solvePanel.SetActive(false);
        }
    }
}
