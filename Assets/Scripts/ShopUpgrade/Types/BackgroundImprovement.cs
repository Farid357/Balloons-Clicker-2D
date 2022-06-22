using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Shop
{
    public sealed class BackgroundImprovement : Improvement
    {
        [SerializeField] private Image _backGround;
        public Sprite Sprite { get; private set; }

        public void SetSprite(Sprite sprite) => Sprite = sprite;

        protected override void EndUpgradeFeedBack(int upgradeCount)
        {
            _backGround.sprite = Sprite;
        }
    }
}