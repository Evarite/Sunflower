using Sunflower.Modules;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.Shop
{
    [AddComponentMenu("Sunflower/Shop/Module Shop Item")]
    public class ModuleShopItemUI : MonoBehaviour
    {
        [SerializeField] private ModuleData _moduleData;
        [SerializeField] private Button _button;

        public ModuleData ModuleData => _moduleData;

        private void Awake()
        {
            if (_button == null)
                _button = GetComponent<Button>();

            if (_button != null)
                _button.onClick.AddListener(OnClicked);
        }

        private void OnDestroy()
        {
            if (_button != null)
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