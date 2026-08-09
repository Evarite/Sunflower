using UnityEngine;

namespace Sunflower.Restart
{
    public static class CalculateEvoPoints
    {
        public static int Calculate(float x) => (int)(1 / 9 * Mathf.Pow(x, Mathf.Log(3, 2) * 1.2f));
    }
}