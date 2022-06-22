using UnityEngine;
using UnityEngine.EventSystems;
using Clicker.SaveSystem;
using System;

namespace Clicker.Shop
{
    public class ImprovementSelector : MonoBehaviour, IPointerClickHandler
    {
        public event Action<BuyingImprovement> OnSelecting;
        [SerializeField] private ImprovementGenerator _generator;
        private string _key = "SelectedImprovement";
        private IStorage _storage = new BinaryStorage();

        [SerializeField] private int _selected;
        private int _next;

        private void Start()
        {
            _key = gameObject.name + transform.position + ".txt";
            _selected = _storage.Load(_key, _selected);
            if (_selected == 0)
                _selected = -1;
            else
                _next = _selected + 1;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject.TryGetComponent(out BuyingImprovement improvement))
            {
                if (_generator.Improvements[_next].transform.position == improvement.transform.position)
                {
                    OnSelecting?.Invoke(improvement);
                    improvement.TryBuy(Select);
                }
            }
        }

        private void Select()
        {
            _selected = _next;
            _storage.Save(_key, _selected);
            _next++;
        }
    }
}