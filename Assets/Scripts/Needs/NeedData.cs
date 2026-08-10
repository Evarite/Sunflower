
using UnityEngine;

namespace Sunflower.Needs
{
    [CreateAssetMenu(fileName = "needData", menuName = "Sunflower/Needs/Need Data")]
    public class NeedData : ScriptableObject
    {
        public string displayName = "Need";
        public float baseCapacity = 100f;
        public float baseFillRate = 1f;
    }
}