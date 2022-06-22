using System.Collections;
using UnityEngine;
using Zenject;

namespace Clicker.GameLogic
{
    public sealed class TimeClickBonus : MonoBehaviour
    {
        [SerializeField, Range(0.2f, 30f)] private float _delay = 3f;
        [SerializeField] private CoinsCollector _collector;
        [SerializeField] private int _bonus = 3;
        private WaitForSeconds _wait;

        private IEnumerator Start()
        {
            _wait = new WaitForSeconds(_delay);
            while (true)
            {
                yield return _wait;
                _collector.Add(_bonus);
            }
        }
    }
}
