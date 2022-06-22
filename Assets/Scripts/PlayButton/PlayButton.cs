using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Clicker.Tools;

namespace Clicker.GameLogic
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Button))]
    public sealed class PlayButton : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private List<Color> _chosedColors = new();
        private RectTransform _rectTransform;

        public Vector3 Size => _spriteRenderer.bounds.size;
        public Button Button { get; private set; }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            Button = GetComponent<Button>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void TrySetColor(Color[] colors, int spawnCount)
        {
            _rectTransform.localPosition = new Vector3(_rectTransform.localPosition.x, _rectTransform.localPosition.y, 0);
            var color = new Color().GetRandom(colors);

            if (colors.Length < spawnCount)
                throw new System.InvalidOperationException("Colors count have to equal to play button count!");


            if (_chosedColors.Contains(color) == false)
            {
                _chosedColors.Add(color);
                Button.image.color = color;
                return;
            }
            else
            {
                TrySetColor(colors, spawnCount);
            }
        }
    }
}
