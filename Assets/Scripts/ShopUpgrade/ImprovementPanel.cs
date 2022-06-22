using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace Clicker.Shop
{
    public sealed class ImprovementPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _needCoinsCountText;
        [SerializeField] private TextMeshProUGUI _needUpgradeCountText;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private TextMeshProUGUI _confirmText;
        [SerializeField] private TextMeshProUGUI _invalidCofirmText;

        public void RegisterCofirmButton(UnityAction action)
        {
            _confirmButton.onClick.RemoveAllListeners();
            _confirmButton.onClick.AddListener(action);
            _confirmButton.onClick.AddListener(delegate { gameObject.SetActive(false); });
        }

        public void Show(int needCoins, int upgradeCount)
        {
            _needCoinsCountText.text = needCoins.ToString();
            _needUpgradeCountText.text = upgradeCount.ToString();
            gameObject.SetActive(true);
        }

        public void ShowInvalidCofirmText()
        {
            _confirmText.gameObject.SetActive(false);
            _invalidCofirmText.gameObject.SetActive(true);
            _confirmButton.onClick.RemoveAllListeners();
        }
    }
}