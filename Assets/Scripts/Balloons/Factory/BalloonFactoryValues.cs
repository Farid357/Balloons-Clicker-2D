using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class BalloonFactoryValues : MonoBehaviour
    {
        public Transform[] Points => _points;
        [SerializeField] private Transform[] _points;
        private int _time;
        private const float MaxTime = 30;

        private void Start() => StartCoroutine(StartTimer());

        private IEnumerator StartTimer()
        {
            while (true)
            {
                if (_time >= MaxTime)
                    _time = 0;
                yield return new WaitForSeconds(1);
                _time += 1;
            }
        }

        public Balloon GetBalloon(Balloon[] balloons)
        {
            List<float> chances = new();
            for (int i = 0; i < balloons.Length - 1; i++)
            {
                chances.Add(balloons[i].CurveFromTime.Evaluate(_time));
            }
            float chance = UnityEngine.Random.Range(0, chances.Sum());
            float value = 0;

            for (int i = 0; i < chances.Count; i++)
            {
                value += chances[i];
                if (chance < value)
                {
                    return balloons[i];
                }
            }
            return balloons[balloons.Length - 2];
        }
    }
}
