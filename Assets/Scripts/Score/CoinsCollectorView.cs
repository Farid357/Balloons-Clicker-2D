using UnityEngine;
using TMPro;

namespace Clicker.GameLogic
{
    public sealed class CoinsCollectorView : MonoBehaviour
    {
        public TextMeshProUGUI Text => _coinsText;
        [SerializeField] private CoinsCollector _collector;
        [SerializeField] private TextMeshProUGUI _coinsText;


        private void OnEnable() => _collector.OnChanged += Display;

        private void OnDisable() => _collector.OnChanged -= Display;

        private void Display(int count) => _coinsText.text = count.ToString();
    }
}
