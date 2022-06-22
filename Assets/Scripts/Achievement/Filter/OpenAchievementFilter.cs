using Clicker.GameLogic;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Clicker.Tools
{
    public sealed class OpenAchievementFilter : IAchievementSort
    {

        public void Sort(List<Achievement> achievements)
        {
            Disable(achievements);
            var sortedAchievements = new List<Achievement>();
            sortedAchievements.AddRange(achievements.Where(a => !a.IsClosed));

            for (int i = 0; i < sortedAchievements.Count(); i++)
            {
                sortedAchievements[i].gameObject.SetActive(true);
            }
        }

        private void Disable(List<Achievement> achievements)
        {
            achievements.ForEach(a => a.gameObject.SetActive(false));
        }
    }
}