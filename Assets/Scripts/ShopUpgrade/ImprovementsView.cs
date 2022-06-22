using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System.Collections;

namespace Clicker.Shop
{
    public sealed class ImprovementsView : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onUpgraded;
        private List<BuyingImprovement> _improvements;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.3f);
            _improvements = FindObjectsOfType<BuyingImprovement>().ToList();
            _improvements.ForEach(i => i.OnBuyed += Disable);
            var notBuyedImprovements = _improvements.Where(i => i.IsBuyed);

            foreach (var improvement in notBuyedImprovements)
            {
                improvement.gameObject.SetActive(false);
            }
        }

        private void OnDisable() => _improvements.ForEach(i => i.OnBuyed -= Disable);

        private void Disable(BuyingImprovement improvement)
        {
            _onUpgraded?.Invoke();
            improvement.gameObject.SetActive(false);
        }
    }
}