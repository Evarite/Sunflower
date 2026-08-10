using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SaveSystem.Data
{
    [Serializable]
    public class ModuleSaveData
    {
        [SerializeField] private List<ModuleSlotSaveData> _slots = new();
        [SerializeField] private float _currentHeight;

        public IReadOnlyList<ModuleSlotSaveData> Slots => _slots;
        public float CurrentHeight => _currentHeight;

        public ModuleSaveData()
        {
        }

        public ModuleSaveData(
            List<ModuleSlotSaveData> slots,
            float currentHeight)
        {
            _slots = slots;
            _currentHeight = currentHeight;
        }
    }
}