using UnityEngine;
using Zenject;
using TMPro;

namespace Clicker.GameLogic
{
    public sealed class BalloonX3 : Balloon
    {
        [SerializeField, Min(1)] private int _delay = 2;
        private TextMeshProUGUI _textX3;
        private BalloonBonusTimer _timer;
        private WaitForSeconds _wait;
        private const int Cofficient = 3;

        private void OnEnable() => _wait = new WaitForSeconds(_delay);

        [Inject]
        public void Init([Inject(Id = InjectId.X3)] TextMeshProUGUI textX3, BalloonBonusTimer timer)
        {
            _textX3 = textX3;
            _timer = timer;
        }

        public override void Apply()
        {
            PlaySound(CatchClip);
            _timer.Enable(_textX3, Cofficient, _wait);
        }
    }
}
