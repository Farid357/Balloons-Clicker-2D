using System;
using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class BalloonsFactoryPoints
    {
        public Transform GetRandomPoint(Transform[] points)
        {
            if (points.Length <= 1)
                throw new InvalidOperationException("Point length bellow 1!");

            var index = UnityEngine.Random.Range(0, points.Length);
            return points[index];
        }
    }

}
