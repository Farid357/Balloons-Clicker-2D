using UnityEngine;
using Clicker.GameLogic;
using Clicker.SaveSystem;
using UnityEngine.UI;
using System;

namespace Clicker.Shop
{
    [RequireComponent(typeof(Improvement), typeof(Image))]
    public sealed class BuyingImprovement : MonoBehaviour
    {
        public event Action<BuyingImprovement> OnBuyed;
        private event Action _onBuying;

        private ImprovementPanel _panel;
        private CoinsCollector _collector;
        private IStorage _storage = new BinaryStorage();
        private string _key;
        public Improvement Improvement { get; private set; }

        public bool IsBuyed { get; private set; }

        [Zenject.Inject]
        public void Init(CoinsCollector collector) => _collector = collector;

        public void SetPanel(ImprovementPanel panel) => _panel = panel;

        private void Awake()
        {
            Improvement = GetComponent<Improvement>();
            Invoke(nameof(SetKey), 0.2f);
        }

        private void SetKey()
        {
            _key = $"{Improvement.NeedCoins} {Improvement.UpgradeCount} {transform.position} a";
            IsBuyed = _storage.Load(_key, IsBuyed);
        }

        public void TryBuy(Action onbuying)
        {
            _onBuying += onbuying;
            _panel.Show(Improvement.NeedCoins, Improvement.UpgradeCount);
            if (_collector.TryRemove(Improvement.NeedCoins))
            {
                _panel.RegisterCofirmButton(delegate { Buy(); });
            }

            else
            {
                _panel.ShowInvalidCofirmText();
            }
        }

        private void Buy()
        {
            IsBuyed = true;
            _storage.Save(_key, IsBuyed);
            Improvement.Upgrade();
            OnBuyed.Invoke(this);
            _collector.Remove(Improvement.NeedCoins);
            _onBuying?.Invoke();
        }

        private void OnDisable() => _onBuying = null;
    }
}