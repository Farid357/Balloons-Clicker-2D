using Clicker.GameLogic;
using System.Collections.Generic;

namespace Clicker.Tools
{
    public sealed class StandartAchievementFilter : IAchievementSort
    {
        public void Sort(List<Achievement> achievements)
        {
            achievements.ForEach(a => a.gameObject.SetActive(true));
        }
    }
}