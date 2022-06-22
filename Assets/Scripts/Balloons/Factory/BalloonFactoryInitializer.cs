using UnityEngine;
using Clicker.Tools;

namespace Clicker.GameLogic
{
    public sealed class BalloonFactoryInitializer : MonoBehaviour
    {
        [SerializeField] private Color[] _colors;
        [SerializeField] private BalloonsFactory _factory;
        [SerializeField] private BalloonFactoryValues _values;
        private readonly BalloonsFactoryPoints _points = new();

        private void OnEnable() => _factory.OnSpawned += Init;

        private void OnDestroy() => _factory.OnSpawned -= Init;

        public void Init(Balloon balloon)
        {
            var point = _points.GetRandomPoint(_values.Points);
            if (balloon is StandartBalloon)
                balloon.SpriteRenderer.color = new Color().GetRandom(_colors);
            balloon.SpriteRenderer.enabled = true;
            balloon.gameObject.SetActive(true);
            balloon.transform.position = point.position;
            balloon.transform.rotation = Quaternion.identity;
        }
    }
}
