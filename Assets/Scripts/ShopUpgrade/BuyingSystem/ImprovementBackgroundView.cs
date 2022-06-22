using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Shop
{
    public sealed class ImprovementBackgroundView : MonoBehaviour
    {
        [SerializeField] private ImprovementSelector _selector;
        [SerializeField] private Image _backgroundOnPanel;

        private void OnEnable() => _selector.OnSelecting += Show;
  
        private void OnDestroy() => _selector.OnSelecting -= Show;


        private void Show(BuyingImprovement buyingImprovement)
        {
            if (buyingImprovement.gameObject.TryGetComponent(out BackgroundImprovement improvement))
            {
                _backgroundOnPanel.sprite = improvement.Sprite;
            }
        }
    }
}