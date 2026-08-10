using UnityEngine;
using UnityEngine.EventSystems;

namespace Sunflower.Shop
{
    public class ShopPointerHandler : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            ModuleShopUI.Instance?.SetPointerOverShop(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ModuleShopUI.Instance?.SetPointerOverShop(false);
        }
    }
}