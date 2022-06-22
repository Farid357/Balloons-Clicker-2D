using UnityEngine;

namespace Clicker.GameLogic
{
    [RequireComponent(typeof(ClickerHandler), typeof(RectTransform))]
    public sealed class ClickerView : MonoBehaviour
    {
        private ClickerHandler _clicker;

        private RectTransform _rect;
        private Vector3 _startSize;


        private void OnEnable()
        {
            _clicker = GetComponent<ClickerHandler>();
            _rect = GetComponent<RectTransform>();

            _clicker.OnUpped += DecreaseSize;
            _clicker.OnDowned += IncreaseSize;
            _startSize = _rect.sizeDelta;
        }

        private void OnDestroy()
        {
            _clicker.OnUpped -= DecreaseSize;
            _clicker.OnDowned -= IncreaseSize;
        }


        private void IncreaseSize() => _rect.sizeDelta *= 0.95f;

        private void DecreaseSize() => _rect.sizeDelta = _startSize;
    }
}
