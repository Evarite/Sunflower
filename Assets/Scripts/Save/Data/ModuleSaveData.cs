using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [Serializable]
    public class ModuleSaveData
    {
        [SerializeField] private List<Vector3> _slotPositions = new();
        [SerializeField] private float _currentHeight;

        public List<Vector3> SlotPositions => _slotPositions;
        public float CurrentHeight => _currentHeight;

        public ModuleSaveData()
        {
        }

        public ModuleSaveData(
            List<Vector3> slotPositions,
            float currentHeight)
        {
            _slotPositions = slotPositions;
            _currentHeight = currentHeight;
        }
    }
}