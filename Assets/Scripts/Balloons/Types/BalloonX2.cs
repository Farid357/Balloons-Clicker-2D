using UnityEngine;
using TMPro;
using Zenject;

namespace Clicker.GameLogic
{
    public sealed class BalloonX2 : Balloon
    {
        [SerializeField, Min(1)] private int _delay = 2;
        private BalloonBonusTimer _timer;
        private TextMeshProUGUI _textX2;
        private WaitForSeconds _wait;
        private const int Cofficient = 2;

        private void OnEnable() => _wait = new WaitForSeconds(_delay);

        [Inject]
        public void Init([Inject(Id = InjectId.X2)] TextMeshProUGUI text2X, BalloonBonusTimer timer)
        {
            _textX2 = text2X;
            _timer = timer;
        }

        public override void Apply()
        {
            PlaySound(CatchClip);
            _timer.Enable(_textX2, Cofficient, _wait);
        }

    }
}
