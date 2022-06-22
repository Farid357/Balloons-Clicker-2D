using UnityEngine;
using Zenject;

namespace Clicker.GameLogic
{
    public sealed class BalloonEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _prefab;
        private BalloonsCatcher _catcher;

        [Inject]
        public void Init(BalloonsCatcher catcher) => _catcher = catcher;


        private void OnEnable() => _catcher.OnCatching += Play;

        private void OnDestroy() => _catcher.OnCatching -= Play;

        private void Play(Color color, Vector3 position)
        {
            var effect = Instantiate(_prefab, position, Quaternion.identity);
            var main = effect.main;
            main.startColor = color;
            effect.Play();
        }
    }
}
