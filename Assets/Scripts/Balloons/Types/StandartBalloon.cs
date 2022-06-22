using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class StandartBalloon : Balloon
    {
        [SerializeField] private int _count = 5;

        public void SetBonusCount(int count)
        {
            if (count <= 0)
                throw new System.ArgumentOutOfRangeException(nameof(count));
            _count = count;
        }

        public override void Apply()
        {
            Collector.Add(_count);
        }
    }
}
