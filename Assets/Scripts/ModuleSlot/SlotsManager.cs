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

        public Slot GetAvailableSlot(SlotType slotType)
        {
            foreach (Slot slot in _slots)
            {
                if (slot == null)
                    continue;

                if (slot.SlotType != slotType)
                    continue;

                if (slot.IsAvailable())
                    return slot;
            }

            return null;
        }

        public IReadOnlyList<Slot> GetSlots(SlotType slotType)
        {
            List<Slot> result = new();

            foreach (Slot slot in _slots)
            {
                if (slot != null && slot.SlotType == slotType)
                    result.Add(slot);
            }

            return result;
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