using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SaveSystem.Data
{
    [System.Serializable]
    public class SunflowerSaveData
    {
        [SerializeField] private float _height;
        [SerializeField] private List<float> _needsValues;

        public SunflowerSaveData(float height, List<float> needsValues)
        {
            _height = height;
            _needsValues = needsValues;
        }

        public float Height => _height;
        public List<float> NeedsValues => _needsValues;
    }
}