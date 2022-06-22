using UnityEngine;
using Zenject;

namespace Clicker.GameLogic
{
    public sealed class FakeBalloon : Balloon
    {
        [SerializeField] private int _removeCount;
        [SerializeField] private float _delayFromChangeCoinsTextColor = 0.6f;
        [SerializeField] private Color _changeCoinsTextColor;
        private CoinsTextColor _coinsTextColor;

        public void SetRemoveCount(int removeCount)
        {
            if (removeCount <= 0) throw new System.ArgumentOutOfRangeException(nameof(removeCount));
            _removeCount = removeCount;
        }

        [Inject]
        public void Init(CoinsTextColor coinsTextColor) => _coinsTextColor = coinsTextColor;

        public override void Apply()
        {
            Handheld.Vibrate();
            PlaySound(CatchClip);
            Collector.Remove(_removeCount);
            _coinsTextColor.StartChangeColor(_delayFromChangeCoinsTextColor, _changeCoinsTextColor);
        }
    }
}
