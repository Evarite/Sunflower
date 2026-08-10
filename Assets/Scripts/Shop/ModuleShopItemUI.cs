using Sunflower.Modules;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.Shop
{
    public class ModuleShopItemUI : MonoBehaviour
    {
        [SerializeField] private ModuleData _moduleData;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            if (ModuleShopUI.Instance == null)
                return;

            ModuleShopUI.Instance.TryInstall(_moduleData);
        }
    }
}