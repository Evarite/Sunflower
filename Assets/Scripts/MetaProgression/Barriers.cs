using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.MetaProgression
{
    [CreateAssetMenu(fileName = "Progress Barriers", menuName = "Sunflower/Growth/Barriers")]
    public class Barriers : ScriptableObject
    {
        [Tooltip("Список максимальных высот для каждого забега")]
        [SerializeField] private List<float> _maxHeights;

        public List<float> MaxHeights => _maxHeights;
    }
}