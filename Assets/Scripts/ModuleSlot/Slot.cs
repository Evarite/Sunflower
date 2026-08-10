using Sunflower.Modules;
using UnityEngine;

namespace Sunflower.ModuleSlot
{
    [AddComponentMenu("Sunflower/Module Slot/Slot")]
    public class Slot : MonoBehaviour
    {
        [SerializeField] private SlotType _slotType;
        [SerializeField] private float _minHeight;
        [SerializeField] private float _maxHeight;

        public SlotType SlotType => _slotType;
        public float MinHeight => _minHeight;
        public float MaxHeight => _maxHeight;

        public ModuleRuntime InstalledModule { get; private set; }

        public bool IsOccupied =>
            InstalledModule != null;

        public void Initialize(
            float minHeight,
            float maxHeight)
        {
            _minHeight = minHeight;
            _maxHeight = maxHeight;
        }

        public bool IsAvailable()
        {
            return InstalledModule == null;
        }

        public bool CanInstall(ModuleData moduleData)
        {
            if (moduleData == null)
                return false;

            if (IsOccupied)
                return false;

            if (moduleData.AllowedSlot != _slotType)
                return false;

            if (moduleData.AlivePrefab == null)
                return false;

            return true;
        }

        public bool TryInstall(ModuleData moduleData)
        {
            if (!CanInstall(moduleData))
                return false;

            GameObject moduleObject = Instantiate(
                moduleData.AlivePrefab,
                transform.position,
                Quaternion.identity,
                transform
            );

            ModuleRuntime moduleRuntime =
                moduleObject.GetComponent<ModuleRuntime>();

            if (moduleRuntime == null)
            {
                Debug.LogError(
                    $"Module prefab '{moduleData.AlivePrefab.name}' " +
                    $"does not contain a {nameof(ModuleRuntime)}.",
                    moduleObject
                );

                Destroy(moduleObject);
                return false;
            }

            moduleRuntime.Data = moduleData;

            InstalledModule = moduleRuntime;

            return true;
        }

        public ModuleRuntime RemoveModule()
        {
            if (InstalledModule == null)
                return null;

            ModuleRuntime module = InstalledModule;

            InstalledModule = null;

            Destroy(module.gameObject);

            return module;
        }
    }
}