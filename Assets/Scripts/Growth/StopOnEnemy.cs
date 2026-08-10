using UnityEngine;

namespace Sunflower.Growth
{
    [RequireComponent(typeof(SunflowerGrowth))]
    public class StopOnEnemy : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
    }
}