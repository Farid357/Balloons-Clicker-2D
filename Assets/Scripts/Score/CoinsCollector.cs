using System;
using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class CoinsCollector : MonoBehaviour
    {
        public event Action<int> OnChanged;
        private readonly CoinsStorage _storage = new();
        private int _coinsCount;
        private int _cofficient = 1;

        public bool TryRemove(int count) => _coinsCount - count >= 0;

        private void Start()
        {
            _coinsCount = _storage.Load();
            OnChanged.Invoke(_coinsCount);
        }

        public void Add(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("add count is 0 or below!");
            _coinsCount += count * _cofficient;
            OnChanged?.Invoke(_coinsCount);
            _storage.Save(_coinsCount);
        }

        public void SetCofficient(int cofficient)
        {
            if (cofficient <= 0)
                throw new ArgumentOutOfRangeException(nameof(cofficient));

            _cofficient = cofficient;
        }

        public void Remove(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (TryRemove(count))
            {
                _coinsCount -= count;
                _storage.Save(_coinsCount);
                OnChanged?.Invoke(_coinsCount);
            }
        }
    }
}
