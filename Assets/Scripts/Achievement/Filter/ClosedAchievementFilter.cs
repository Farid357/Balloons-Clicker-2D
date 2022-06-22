using Clicker.GameLogic;
using System.Collections.Generic;
using System.Linq;

namespace Clicker.Tools
{
    public sealed class ClosedAchievementFilter : IAchievementSort
    {
        public void Sort(List<Achievement> achievements)
        {
            Disable(achievements);
            foreach (var achievement in achievements.Where(a => a.IsClosed))
            {
                achievement.gameObject.SetActive(true);
            }
        }

        private void Disable(List<Achievement> achievements)
        {
            achievements.ForEach(a => a.gameObject.SetActive(false));
        }
    }
}