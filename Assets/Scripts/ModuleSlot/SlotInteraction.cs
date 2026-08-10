using Sunflower.Shop;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sunflower.ModuleSlot
{
    public class SlotInteraction : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerClickHandler
    {
        private Slot _slot;

        private void Awake()
        {
            _slot = GetComponent<Slot>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_slot == null)
                return;

            ModuleShopUI.Instance?.OnSlotPointerEnter();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_slot == null)
                return;

            ModuleShopUI.Instance?.OnSlotPointerExit();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_slot == null)
                return;

            if (!_slot.IsAvailable())
                return;

            ModuleShopUI.Instance?.Open(_slot);
        }
    }
}