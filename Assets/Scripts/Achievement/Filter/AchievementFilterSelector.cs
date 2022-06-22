using UnityEngine;
using Clicker.GameLogic;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

namespace Clicker.Tools
{
    public sealed class AchievementFilterSelector : MonoBehaviour
    {
        [SerializeField] private Button _filterButton;

        [SerializeField] private List<Achievement> _achievements = new();
        private IAchievementSort[] _achievementSorts = new IAchievementSort[4];
        private int _index;

        private int Count => _achievementSorts.Length - 1;

        private void Start()
        {
            _achievementSorts = new IAchievementSort[]
            {
                new StandartAchievementFilter(),
                new ClosedAchievementFilter(),
                new OpenAchievementFilter()
            };

            _filterButton.onClick.AddListener(ShowNext);
            _achievementSorts[_index].Sort(_achievements);
        }

        private void ShowNext()
        {
            _index++;
            if (_index > Count)
                _index = 0;
            _achievementSorts[_index].Sort(_achievements);
        }
    }

    public interface IAchievementSort
    {
        public void Sort(List<Achievement> achievements);
    }
}