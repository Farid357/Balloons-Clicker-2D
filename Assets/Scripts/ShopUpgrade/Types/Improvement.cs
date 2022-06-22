using UnityEngine;

namespace Clicker.Shop
{
    public abstract class Improvement : MonoBehaviour
    {
        private int _needCoins;
        private int _upgradeCount;

        public int NeedCoins => _needCoins;
        public int UpgradeCount => _upgradeCount;

        public void Init(int needCoins, int upgradeCount)
        {
            _needCoins = needCoins;
            _upgradeCount = upgradeCount;
        }

        protected abstract void EndUpgradeFeedBack(int upgradeCount);

        public void Upgrade()
        {
            EndUpgradeFeedBack(_upgradeCount);
        }
    }
}