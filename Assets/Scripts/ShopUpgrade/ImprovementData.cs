using System.Collections.Generic;
using UnityEngine;

namespace Clicker.Shop
{
    [System.Serializable]
    public sealed class ImprovementData : MonoBehaviour
    {
        public List<Data> Improvements => _datas;
        [SerializeField] private List<Data> _datas = new();

        [System.Serializable]
        public sealed class Data
        {
            [SerializeField] private int _needCoins;
            [SerializeField] private int _upgradeCount;
            public int NeedCount => _needCoins;
            public int UpgradeCount => _upgradeCount;
        }
    }
}