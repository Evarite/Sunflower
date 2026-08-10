using Sunflower.SaveSystem;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.ModuleSlot
{
    [AddComponentMenu("Sunflower/Module Slot/Slots Manager")]
    public class SlotsManager : MonoBehaviour
    {
        private readonly List<GameObject> _slots = new();

        public IReadOnlyList<GameObject> AllSlots => _slots;

        public void AddSlot(GameObject slot)
        {
            if (slot != null)
                _slots.Add(slot);
        }

        public void RemoveSlot(GameObject slot)
        {
            _slots.Remove(slot);
        }

        public ModuleSaveData GetSaveData(float currentHeight)
        {
            List<Vector3> positions = new(_slots.Count);

            foreach (GameObject slot in _slots)
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
                GameObject slot = Instantiate(
                    slotPrefab,
                    position,
                    Quaternion.identity
                );

                _slots.Add(slot);
            }
        }

        private void Clear()
        {
            foreach (GameObject slot in _slots)
            {
                if (slot != null)
                    Destroy(slot);
            }

            _slots.Clear();
        }
    }
}