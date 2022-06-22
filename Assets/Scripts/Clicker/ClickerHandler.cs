using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Clicker.GameLogic
{
    public sealed class ClickerHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnUpped;
        public event Action OnDowned;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private CoinsCollector _collector;
        private const int Count = 1;

        //
        public void OnPointerUp(PointerEventData eventData) => OnUpped?.Invoke();

        public void OnPointerDown(PointerEventData eventData) => OnDowned?.Invoke();

        public void OnPointerClick(PointerEventData eventData)
        {
            _audio.PlayOneShot(_audio.clip);
            _collector.Add(Count);
        }
    }
}
