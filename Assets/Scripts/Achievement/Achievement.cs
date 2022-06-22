using Clicker.SaveSystem;
using System;
using UnityEngine;
using Zenject;

namespace Clicker.GameLogic
{
    [Serializable]
    public sealed class Achievement : MonoBehaviour
    {
        public event Action OnClaimed;
        [SerializeField] private int _applyCount;
        [SerializeField] private int _coinCount;
        [SerializeField] private AchievementType _type;
        
        private CoinsCollector _collector;
        private IStorage _storage = new BinaryStorage();
        private string _key = "Achievement";

        public int CoinCount => _coinCount;
        public AchievementType Type => _type;
        public bool IsClosed { get; private set; } = true;

        private void Awake()
        {
            _key = $"{_coinCount} {_applyCount} {IsClosed}";
            IsClosed = _storage.Load(_key, IsClosed);
        }

        [Inject]
        public void Init(CoinsCollector collector) => _collector = collector;

        public void Constructor(int coinCount, AchievementType type, int applyCount)
        {
            if (coinCount <= 0 || string.IsNullOrEmpty(_key) || applyCount <= 0)
                throw new ArgumentOutOfRangeException("Coin count is below 0 or key is empty!");
            _coinCount = coinCount;
            _type = type;
            _applyCount = applyCount;
        }

        public void TryClaimReward(int count)
        {
            if (_applyCount <= count && IsClosed)
            {
                IsClosed = false;
                ClaimReward();
                _storage.Save(_key, IsClosed);
            }
        }

        private void ClaimReward()
        {
            _collector.Add(_coinCount);
            OnClaimed?.Invoke();
        }
    }
}
