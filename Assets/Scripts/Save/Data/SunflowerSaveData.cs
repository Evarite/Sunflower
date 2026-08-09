using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [System.Serializable]
    public class SunflowerSaveData
    {
        [SerializeField] private float _height;
        [SerializeField] private float _growthSpeed;
        [SerializeField] private List<float> _needsValues;

        public SunflowerSaveData(float Height, float GrowthSpeed, List<float> NeedsValues)
        {
            _height = Height;
            _growthSpeed = GrowthSpeed;
            _needsValues = NeedsValues;
        }

        public float Height => _height;
        public float GrowthSpeed => _growthSpeed;
        public List<float> NeedsValues => _needsValues;
    }
}