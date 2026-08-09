using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.ModuleSlot
{
    [AddComponentMenu("Sunflower/Module Slot/Slots Manager")]
    public class SlotsManager : MonoBehaviour
    {
        private List<GameObject> _slots = new();

        public void AddSlot(GameObject slot) => _slots.Add(slot);
    }
}