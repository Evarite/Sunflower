using Sunflower.Modules;
using UnityEngine;

namespace Sunflower.ModuleSlot
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private SlotType _slotType;
        [SerializeField] private float _minHeight;
        [SerializeField] private float _maxHeight;

        public SlotType SlotType { get => _slotType; }
        public float MinHeight => _minHeight;
        public float MaxHeight => _maxHeight;
        public bool IsOccupied { get; set; }
        public ModuleRuntime InstalledModule { get; set; }

        public void Initialize(float minHeight, float maxHeight)
        {
            _minHeight = minHeight;
            _maxHeight = maxHeight;
        }

        public bool IsAvailable() => !IsOccupied;
    }
}