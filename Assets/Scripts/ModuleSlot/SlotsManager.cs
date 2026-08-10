using Sunflower.SaveSystem;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.ModuleSlot
{
    [AddComponentMenu("Sunflower/Module Slot/Slots Manager")]
    public class SlotsManager : MonoBehaviour
    {
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
            List<Vector3> positions = new(_slots.Count);

            foreach (Slot slot in _slots)
            {
                if (slot != null)
                    positions.Add(slot.transform.position);
            }

            return new ModuleSaveData(
                positions,
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

            foreach (Vector3 position in data.SlotPositions)
            {
                GameObject slotObject = Instantiate(
                    slotPrefab,
                    position,
                    Quaternion.identity,
                    transform
                );

                Slot slot = slotObject.GetComponent<Slot>();

                if (slot == null)
                {
                    Debug.LogError(
                        $"Slot prefab '{slotPrefab.name}' does not contain a {nameof(Slot)} component.",
                        slotObject
                    );

                    Destroy(slotObject);
                    continue;
                }

                AddSlot(slot);
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