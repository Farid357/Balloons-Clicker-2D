using UnityEngine;
using Zenject;

namespace Clicker.Shop
{
    public sealed class ImprovementGenerator : MonoBehaviour
    {
        [SerializeField] private Sprite[] _backGroundSprites;
        [SerializeField] private Improvement _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private ImprovementData _data;
        [SerializeField] private ImprovementPanel _panel;
        [SerializeField] private bool _spawnBackground;
        private DiContainer _container;
        public Improvement[] Improvements { get; private set; }

        private void Awake() => Generate();

        private void OnValidate()
        {
            if(_spawnBackground && _prefab.GetComponent<BackgroundImprovement>() == null)
            {
                Debug.LogError("Prefab have to contain background improvement component!");
                _prefab = null;
            }
        }

        [Inject]
        public void Init(DiContainer container) => _container = container;

        private void Generate()
        {
            Improvements = new Improvement[_data.Improvements.Count];
            for (int i = 0; i < _data.Improvements.Count; i++)
            {
                var improvement = _container.InstantiatePrefabForComponent<Improvement>(_prefab, _parent);
                improvement.Init(_data.Improvements[i].NeedCount, _data.Improvements[i].UpgradeCount);
                improvement.GetComponent<BuyingImprovement>().SetPanel(_panel);
                if (_spawnBackground)
                    improvement.GetComponent<BackgroundImprovement>().SetSprite(_backGroundSprites[i]);
                Improvements[i] = improvement;

            }
        }
    }
}