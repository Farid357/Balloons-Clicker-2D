using Clicker.GameLogic;
using UnityEngine;

namespace Clicker.Shop
{
    public sealed class BalloonBonusImprovement : Improvement
    {
        [SerializeField] private StandartBalloon _standartBalloon;

        protected override void EndUpgradeFeedBack(int upgradeCount)
        {
            _standartBalloon.SetBonusCount(upgradeCount);
        }
    }
}