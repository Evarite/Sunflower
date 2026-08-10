using Sunflower.Modules;
using Sunflower.SaveSystem.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.ModuleSlot
{
    [AddComponentMenu("Sunflower/Module Slot/Slots Manager")]
    public class SlotsManager : MonoBehaviour
    {
        [SerializeField] private ModuleDatabase _moduleDatabase;

        private readonly List<Slot> _slots = new();

        public IReadOnlyList<Slot> AllSlots => _slots;

        public void AddSlot(Slot slot)
        {
            if (slot == null)
                return;

            if (_slots.Contains(slot))
                return;

            _slots.Add(slot);
        }

        public void RemoveSlot(Slot slot)
        {
            if (slot == null)
                return;

            _slots.Remove(slot);
        }

        public ModuleSaveData GetSaveData(float currentHeight)
        {
            List<ModuleSlotSaveData> slots =
                new(_slots.Count);

            foreach (Slot slot in _slots)
            {
                if (slot == null)
                    continue;

                string moduleId = null;

                if (slot.InstalledModule != null &&
                    slot.InstalledModule.Data != null)
                {
                    moduleId = slot.InstalledModule.Data.Id;
                }

                slots.Add(
                    new ModuleSlotSaveData(
                        slot.transform.position,
                        moduleId
                    )
                );
            }

            return new ModuleSaveData(
                slots,
                currentHeight
            );
        }

        public void Load(
            ModuleSaveData data,
            GameObject slotPrefab)
        {
            if (data == null)
                return;

            Clear();

            foreach (ModuleSlotSaveData slotData in data.Slots)
            {
                if (slotData == null)
                    continue;

                GameObject slotObject = Instantiate(
                    slotPrefab,
                    slotData.Position,
                    Quaternion.identity,
                    transform
                );

                Slot slot = slotObject.GetComponent<Slot>();

                if (slot == null)
                {
                    Debug.LogError(
                        $"Slot prefab '{slotPrefab.name}' " +
                        $"does not contain a {nameof(Slot)} component.",
                        slotObject
                    );

                    Destroy(slotObject);
                    continue;
                }

                AddSlot(slot);

                if (string.IsNullOrEmpty(slotData.ModuleId))
                    continue;

                ModuleData module =
                    _moduleDatabase.GetById(
                        slotData.ModuleId
                    );

                if (module == null)
                {
                    Debug.LogError(
                        $"Could not find module with ID " +
                        $"'{slotData.ModuleId}'."
                    );

                    continue;
                }

                if (!slot.TryInstall(module))
                {
                    Debug.LogError(
                        $"Failed to install module " +
                        $"'{module.ModuleName}' " +
                        $"into loaded slot."
                    );
                }
            }
        }

        public void Clear()
        {
            foreach (Slot slot in _slots)
            {
                if (slot != null)
                    Destroy(slot.gameObject);
            }

            _slots.Clear();
        }
    }
}