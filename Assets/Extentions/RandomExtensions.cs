using UnityEngine;

namespace Clicker.Tools
{
    public static class RandomExtensions
    {
        private static Color[] _colors = new Color[] { Color.red, Color.blue, Color.green, Color.magenta }; 

        public static Color GetRandom(this Color color, Color[] colors = null)
        {
            if (colors is null)
                colors = _colors;

            var index = Random.Range(0, colors.Length);
            return colors[index];
        }
    }
}
