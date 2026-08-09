using Sunflower.Modules;
using UnityEngine;

namespace Sunflower.ModuleSlot
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private SlotType _slotType;
        [SerializeField] private float _minHeight;
        [SerializeField] private float _maxHeight;

        public SlotType SlotType => _slotType;
        public float MinHeight => _minHeight;
        public float MaxHeight => _maxHeight;
        public bool IsOccupied { get; set; }
        public Module InstalledModule { get; set; }

        public Slot(SlotType slotType, float minHeight, float maxHeight)
        {
            _slotType = slotType;
            _minHeight = minHeight;
            _maxHeight = maxHeight;
        }

        public bool IsAvailable(float currentHeight)
        {
            return currentHeight >= _minHeight && currentHeight < _maxHeight && !IsOccupied;
        }
    }
}