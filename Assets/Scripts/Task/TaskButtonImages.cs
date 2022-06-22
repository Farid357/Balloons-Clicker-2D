using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Clicker.GameLogic
{
    public sealed class TaskButtonImages : MonoBehaviour
    {
        [SerializeField] private TaskButtonTimer _taskButton;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _background;
        [SerializeField] private Image _timerTextImage;
        [SerializeField] private GameObject _timerImage;

        private void OnEnable()
        {
            _taskButton.OnTicked += Display;
            _taskButton.OnReseted += ResetImages;
        }

        private void OnDisable()
        {
            _taskButton.OnTicked -= Display;
            _taskButton.OnReseted -= ResetImages;
        }

        private void ResetImages()
        {
            _background.gameObject.SetActive(true);
            _timerTextImage.gameObject.SetActive(true);
            _timerImage.SetActive(false);
        }

        private void Display(int count)
        {
            _text.text = count.ToString();
            if (count <= 0)
            {
                _background.gameObject.SetActive(false);
                _timerImage.SetActive(true);
            }
        }
    }
}
