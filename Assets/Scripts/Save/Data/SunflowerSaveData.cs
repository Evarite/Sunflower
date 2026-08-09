using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [System.Serializable]
    public class SunflowerSaveData
    {
        [SerializeField] private float _height;
        [SerializeField] private List<float> _needsValues;

        public SunflowerSaveData(float Height, List<float> NeedsValues)
        {
            _height = Height;
            _needsValues = NeedsValues;
        }

        public float Height => _height;
        public List<float> NeedsValues => _needsValues;
    }
}