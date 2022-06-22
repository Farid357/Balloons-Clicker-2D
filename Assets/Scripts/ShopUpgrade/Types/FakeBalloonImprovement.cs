using UnityEngine;
using Clicker.GameLogic;

namespace Clicker.Shop
{
    public sealed class FakeBalloonImprovement : Improvement
    {
        [SerializeField] private FakeBalloon _fakeBalloonPrefab;

        protected override void EndUpgradeFeedBack(int upgradeCount)
        {
            _fakeBalloonPrefab.SetRemoveCount(upgradeCount);
        }
    }
}