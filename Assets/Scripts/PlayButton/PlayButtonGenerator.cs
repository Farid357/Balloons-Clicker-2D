using Clicker.LoadSystem;
using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class PlayButtonGenerator : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private Transform _parent;
        [SerializeField] private PlayButton _prefab;
        [SerializeField] private Color[] _colors;
        [SerializeField] private int _xCount;
        [SerializeField] private int _yCount;
        [SerializeField] private SceneData _gameScene;
        private PlayButton[,] _playButtons;
        private const int Difference = 30;

        private void Start()
        {
            _playButtons = new PlayButton[_xCount, _yCount];
            var offset = _prefab.Size + Vector3.one * Difference;
            Generate(offset.x, offset.y);
        }

        public void Generate(float xOffset, float yOffset)
        {
            var startPositionX = transform.position.x;
            var startPositionY = transform.position.y;
            float randomIndexX = Random.Range(0, _xCount);
            float randomIndexY = Random.Range(0, _yCount);

            for (int x = 0; x < _xCount; x++)
            {
                for (int y = 0; y < _yCount; y++)
                {
                    var spawnPoint = new Vector2(startPositionX + (xOffset * x), startPositionY + (yOffset * y));
                    var button = Instantiate(_prefab, spawnPoint, Quaternion.identity, _parent);
                    button.TrySetColor(_colors, _yCount * _xCount);            

                    if (x == randomIndexX && y == randomIndexY)
                        button.Button.onClick.AddListener(delegate { _sceneLoader.Load(_gameScene); });

                    _playButtons[x, y] = button;
                }
            }
        }
    }
}
