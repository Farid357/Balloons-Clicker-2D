using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class AchievementReward : MonoBehaviour
    {
        [SerializeField] private BalloonsCatcher _catcher;
        [SerializeField] private CoinsCollector _collector;
        [SerializeField] private Achievement[] _achievements;
        
        private int _catchedCount;
        private int _coinsCount;

        private void Start()
        {
            _collector.OnChanged += SetCoinsCount;
            _catcher.OnCatched += SetCatchedCount;
        }

        private void OnDisable()
        {
            _collector.OnChanged -= SetCoinsCount;
            _catcher.OnCatched -= SetCatchedCount;
        }

        private void TryFind()
        {
            foreach (var achievement in _achievements)
            {
                if (achievement.Type == AchievementType.Coins)
                    achievement.TryClaimReward(_coinsCount);
                if (achievement.Type == AchievementType.Balloon)
                    achievement.TryClaimReward(_catchedCount);
            }
        }

        private void SetCatchedCount(int count)
        {
            _catchedCount = count;
            TryFind();
        }

        private void SetCoinsCount(int count)
        {
            _coinsCount = count;
            TryFind();
        }
    }
}
