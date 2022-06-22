using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class AnswerTimer : Timer
    {
        [SerializeField] private TaskButtonTimer _task;
        [SerializeField] private GameObject _answerPanel;
        [SerializeField] private AudioSource _openSound;

        protected override void PlayStartFeedback()
        {
            _openSound.Play();
        }

        protected override void PlayEndFeedback()
        {
            _answerPanel.SetActive(false);
            _task.ResetTimer();
        }
    }
}
