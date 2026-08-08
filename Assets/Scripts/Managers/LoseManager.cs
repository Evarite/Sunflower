using UnityEngine;

namespace Sunflower.Managers
{
    public class LoseManager : MonoBehaviour
    {
        public static event System.Action Lost;

        public static void Lose() => Lost?.Invoke();
    }
}