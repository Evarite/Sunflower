using Sunflower.Shop;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sunflower.ModuleSlot
{
    [RequireComponent(typeof(Slot))]
    public class SlotInteraction : MonoBehaviour,
        IPointerClickHandler
    {
        private Slot _slot;

        private void Awake()
        {
            _slot = GetComponent<Slot>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_slot.IsAvailable())
                return;

            ModuleShopUI.Instance?.Open(_slot);
        }
    }
}