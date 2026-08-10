using Sunflower.Modules;
using Sunflower.ModuleSlot;
using UnityEngine;

namespace Sunflower.Shop
{
    [AddComponentMenu("Sunflower/Shop/Module Shop UI")]
    public class ModuleShopUI : MonoBehaviour
    {
        public static ModuleShopUI Instance { get; private set; }

        [SerializeField] private GameObject _shopPanel;

        private Slot _targetSlot;

        private bool _pointerOverSlot;
        private bool _pointerOverShop;

        public Slot TargetSlot => _targetSlot;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            Close();
        }

        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }

        public void Open(Slot slot)
        {
            if (slot == null)
                return;

            if (!slot.IsAvailable())
                return;

            _targetSlot = slot;

            _pointerOverSlot = true;
            _pointerOverShop = false;

            PositionShop(slot);

            _shopPanel.SetActive(true);
        }

        public void Close()
        {
            _targetSlot = null;

            _pointerOverSlot = false;
            _pointerOverShop = false;

            if (_shopPanel != null)
                _shopPanel.SetActive(false);
        }

        public bool TryInstall(ModuleData moduleData)
        {
            if (_targetSlot == null)
                return false;

            if (moduleData == null)
                return false;

            bool installed = _targetSlot.TryInstall(moduleData);

            if (!installed)
                return false;

            Close();

            return true;
        }

        public void SetPointerOverSlot(bool value)
        {
            _pointerOverSlot = value;

            if (!value)
                TryClose();
        }

        public void SetPointerOverShop(bool value)
        {
            _pointerOverShop = value;

            if (!value)
                TryClose();
        }

        private void TryClose()
        {
            if (_pointerOverSlot)
                return;

            if (_pointerOverShop)
                return;

            Close();
        }

        private void PositionShop(Slot slot)
        {
            if (_shopPanel == null)
                return;

            _shopPanel.transform.position = slot.transform.position;
        }
    }
}