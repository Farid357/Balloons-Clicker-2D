using UnityEngine;
using Clicker.Tools;

namespace Clicker.GameLogic
{
    public sealed class BalloonsMovement : MonoBehaviour
    {
        [SerializeField, Range(2, 25)] private float _speed = 3f;
        private readonly Screen _screen = new();

        private void FixedUpdate()
        {
            transform.Translate(Vector2.down * Time.fixedDeltaTime * _speed);
            TryDisable();
        }
        private void TryDisable()
        {
            if (transform.position.y <= _screen.GetMinYWithOffset())
            {
                gameObject.SetActive(false);
            }
        }
    }
}
