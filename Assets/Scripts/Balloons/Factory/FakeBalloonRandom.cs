using Random = UnityEngine.Random;
using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class FakeBalloonRandom : MonoBehaviour
    {
        [SerializeField] private FakeBalloon _balloonPrefab;
        private const int Min = 0;
        private const int Max = 3;

        public FakeBalloon Get()
        {
            var chance = Random.Range(Min, Max);
            if (chance == 2)
                return _balloonPrefab;
            return null;
        }
    }
}
