using UnityEngine;
using Clicker.Tools;
using System.Collections;
using System;
using Zenject;

namespace Clicker.GameLogic
{
    public sealed class BalloonsFactory : MonoBehaviour
    { 
        public event Action<Balloon> OnSpawned;
        [SerializeField] private Balloon[] _balloons;
        [SerializeField, Range(1, 10)] private float _delay;
        [SerializeField] private BalloonFactoryValues _values;
        [SerializeField] private FakeBalloonRandom _randomFakeBalloon;
        private ObjectsPool<Balloon> _pool;
        private WaitForSeconds _wait;

        [Inject]
        public void Init(ObjectsPool<Balloon> pool) => _pool = pool;

        private void Start()
        {
            for (int i = 0; i < _balloons.Length; i++)
            {
                _pool.Add(4, _balloons[i]);
            }
            _wait = new WaitForSeconds(_delay);
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return _wait;

                if (!TryGenerateFakeBalloon())
                {
                    var balloonPrefab = _values.GetBalloon(_balloons);
                    var balloon = _pool.Get(balloonPrefab);
                    OnSpawned?.Invoke(balloon);
                }
            }
        }
        private bool TryGenerateFakeBalloon()
        {
            var fakeBalloonPrefab = _randomFakeBalloon.Get();
            if (fakeBalloonPrefab != null)
            {
                var fakeBalloon = _pool.Get(fakeBalloonPrefab);
                OnSpawned?.Invoke(fakeBalloon);
                return true;
            }
            return false;
        }    
    }
}
