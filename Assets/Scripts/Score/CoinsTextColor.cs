using System.Collections;
using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class CoinsTextColor : MonoBehaviour
    {
        [SerializeField] private CoinsCollectorView _view;

        public void StartChangeColor(float waitTime, Color color)
        {
            StartCoroutine(ChangeColor(waitTime, color));
        }

        private IEnumerator ChangeColor(float waitTime, Color color)
        {
            WaitForSeconds wait = new(waitTime);
            _view.Text.color = color;
            yield return wait;
            _view.Text.color = Color.white;
        }
    }
}