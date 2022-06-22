using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.GameLogic
{
    [RequireComponent(typeof(ClickerHandler), typeof(Outline))]

    public sealed class ClickerOutline : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 1.5f)] private float _delayFromChangeColor;
        [SerializeField] private BalloonsCatcher _catcher;

        private Outline _outline;
        private Color _startOutlineColor;


        private void Start()
        {
            _outline = GetComponent<Outline>();
            _catcher.OnCatching += StartChangeColor;
            _startOutlineColor = _outline.effectColor;
        }


        private void OnDestroy() => _catcher.OnCatching -= StartChangeColor;

        public void StartChangeColor(Color color, Vector3 position) => StartCoroutine(ChangeColor(color));

        private IEnumerator ChangeColor(Color color)
        {
            _outline.effectColor = color;
            yield return new WaitForSeconds(_delayFromChangeColor);
            _outline.effectColor = _startOutlineColor;
        }
    }
}
