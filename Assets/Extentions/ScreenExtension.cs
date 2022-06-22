using UnityEngine;

namespace Clicker.Tools
{
    public static class ScreenExtension
    {
        private static Camera _camera;

        public static float GetMinYWithOffset(this Screen screen)
        {
            _camera = Camera.main;
            var minPosition = _camera.ScreenToWorldPoint(Screen.safeArea.max);
            return -minPosition.y - 2f;
        }
    }
}
