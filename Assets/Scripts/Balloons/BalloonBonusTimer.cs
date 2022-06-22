using System.Collections;
using UnityEngine;
using Zenject;
using TMPro;

namespace Clicker.GameLogic
{
    public sealed class BalloonBonusTimer : MonoBehaviour
    {
        private CoinsCollector _collector;
        private TextMeshProUGUI _lastText;

        [Inject]
        public void Init(CoinsCollector collector) => _collector = collector;

        public void Enable(TextMeshProUGUI text, int cofficient, WaitForSeconds wait)
        {
            TryDisableLastText();
            StartCoroutine(StartBonusTimer(text, cofficient, wait));
            _lastText = text;
        }

        private IEnumerator StartBonusTimer(TextMeshProUGUI text, int cofficient, WaitForSeconds wait)
        {
            Increase(cofficient);
            text.gameObject.SetActive(true);
            yield return wait;
            _collector.SetCofficient(1);
            text.gameObject.SetActive(false);
        }

        private void TryDisableLastText()
        {
            if (_lastText is not null)
                _lastText.gameObject.SetActive(false);
        }

        private void Increase(int cofficient) => _collector.SetCofficient(cofficient);
    }

}
