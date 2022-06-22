using Clicker.Tools;
using UnityEngine;
using Zenject;
using TMPro;
using Clicker.LoadSystem;
using Clicker.Shop;

namespace Clicker.GameLogic
{
    public sealed class AppStart : MonoInstaller
    {
        [SerializeField] private BalloonBonusTimer _timer;
        [SerializeField] private CoinsCollector _collector;
        [SerializeField] private TextMeshProUGUI _2XText;
        [SerializeField] private TextMeshProUGUI _3XText;
        [SerializeField] private AudioSource _balloonCatchSound;
        [SerializeField] private AchievementPanel _achievementPanel;
        [SerializeField] private BalloonsCatcher _catcher;
        [SerializeField] private ImprovementPanel _panel;
        [SerializeField] private CoinsTextColor _coinsTextColor;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.Bind<ObjectsPool<Balloon>>().FromNew().AsSingle();
            Container.BindInstance(_collector).AsSingle();
            Container.Bind<TextMeshProUGUI>().WithId(InjectId.X2).FromInstance(_2XText);
            Container.Bind<TextMeshProUGUI>().WithId(InjectId.X3).FromInstance(_3XText);
            Container.BindInstance(_timer).AsSingle();
            Container.BindInstance(_balloonCatchSound).AsSingle();
            Container.BindInstance(_achievementPanel).AsSingle();
            Container.BindInstance(_catcher).AsSingle();
            Container.Bind<ObjectsPool<TextMeshProUGUI>>().FromNew().AsSingle();
            Container.BindInstance(_coinsTextColor).AsSingle();
            Container.BindInstance(_panel).AsSingle();
        }
    }

    public struct InjectId
    {
        public const string X2 = "X2";
        public const string X3 = "X3";
    }
}
