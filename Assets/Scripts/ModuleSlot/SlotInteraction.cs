using Sunflower.Shop;
using Sunflower.SkillTree.Skills;
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
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                HandleRightClick();
            }
            else
                HandleLeftClick();
        }

        private void HandleLeftClick()
        {
            if (!_slot.IsAvailable())
                return;

            ModuleShopUI.Instance?.Open(_slot);
        }

        private void HandleRightClick()
        {
            if (_slot.IsAvailable())
                return;

            PrunerSkill.Instance.PruneSkill(_slot);
        }
    }
}