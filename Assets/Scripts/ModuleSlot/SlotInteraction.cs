using Sunflower.Shop;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sunflower.ModuleSlot
{
    [RequireComponent(typeof(Slot))]
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
            if (_slot.IsAvailable())
                ModuleShopUI.Instance?.SetPointerOverSlot(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ModuleShopUI.Instance?.SetPointerOverSlot(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_slot.IsAvailable())
                return;

            ModuleShopUI.Instance?.Open(_slot);
        }
    }
}