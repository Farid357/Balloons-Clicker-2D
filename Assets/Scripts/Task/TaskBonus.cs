using UnityEngine;
using UnityEngine.UI;

namespace Clicker.GameLogic
{
    public sealed class TaskBonus : MonoBehaviour
    {
        [SerializeField] private CoinsCollector _collector;
        [SerializeField] private int _score = 100;
        [SerializeField] private Image _correctImage;
        [SerializeField] private Image _wrongImage;

        private void OnEnable()
        {
            _wrongImage.gameObject.SetActive(false);
            _correctImage.gameObject.SetActive(false);
        }

        public void TryApply(bool correct)
        {
            if (correct)
            {
                _collector.Add(_score);
                _correctImage.gameObject.SetActive(true);
            }
            else
            {
                _wrongImage.gameObject.SetActive(true);
            }
        }
    }
}
