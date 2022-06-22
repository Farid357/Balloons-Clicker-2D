using System;
using UnityEngine;
using Clicker.SaveSystem;

namespace Clicker.GameLogic
{
    public sealed class BalloonsCatcher : MonoBehaviour
    {
        public event Action<int> OnCatched;
        public event Action<Color, Vector3> OnCatching;
        private IStorage _storage = new BinaryStorage();

        private Camera _camera;
        private int _catchedCount;
        private const string Key = "BalloonCatched";

        private void Awake()
        {
            _camera = Camera.main;
            _catchedCount = _storage.Load(Key, _catchedCount);
        }

        private void TryCatch(RaycastHit2D raycastHit)
        {
            if (raycastHit.transform.gameObject.TryGetComponent(out Balloon balloon))
            {
                if (balloon.SpriteRenderer.enabled)
                {
                    _catchedCount++;
                    Save();
                    OnCatched?.Invoke(_catchedCount);
                    OnCatching?.Invoke(balloon.SpriteRenderer.color, balloon.transform.position);
                    balloon.Apply();
                    balloon.Disable();
                }
            }
        }

        private void Save() => _storage.Save(Key, _catchedCount);

        private void Update()
        {
            try
            {
                if (Input.touchCount > 0)
                {
                    var touchPosition = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
                    RaycastHit2D raycastHit = Physics2D.Raycast(touchPosition, Vector2.zero);
                    TryCatch(raycastHit);
                }
            }
            catch { }
        }
    }
}