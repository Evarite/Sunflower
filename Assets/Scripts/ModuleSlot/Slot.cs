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

        public ModuleRuntime InstalledModule { get; private set; }

        public bool IsOccupied => InstalledModule != null;

        public void Initialize(float minHeight, float maxHeight)
        {
            _minHeight = minHeight;
            _maxHeight = maxHeight;
        }

        public bool IsAvailable()
        {
            return InstalledModule == null;
        }

        public void Install(ModuleRuntime module)
        {
            if (module == null)
                return;

            if (IsOccupied)
                return;

            InstalledModule = module;
        }

        public ModuleRuntime RemoveModule()
        {
            ModuleRuntime module = InstalledModule;
            InstalledModule = null;
            return module;
        }
    }
}