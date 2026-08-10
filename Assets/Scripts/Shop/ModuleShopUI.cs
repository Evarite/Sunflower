using Sunflower.Modules;
using Sunflower.ModuleSlot;
using UnityEngine;

namespace Sunflower.Shop
{
    public class ModuleShopUI : MonoBehaviour
    {
        public static ModuleShopUI Instance { get; private set; }

        [SerializeField] private GameObject _shopPanel;

        private Slot _targetSlot;

        private bool _pointerOverSlot;
        private bool _pointerOverShop;

        private void Awake()
        {
            Instance = this;
            _shopPanel.SetActive(false);
        }

        public void Open(Slot slot)
        {
            if (slot == null || !slot.IsAvailable())
                return;

            _targetSlot = slot;

            _pointerOverSlot = true;
            _pointerOverShop = false;

            _shopPanel.SetActive(true);

            // Position the shop however you want.
            _shopPanel.transform.position = slot.transform.position;
        }

        public void Close()
        {
            _targetSlot = null;

            _pointerOverSlot = false;
            _pointerOverShop = false;

            _shopPanel.SetActive(false);
        }

        public bool TryInstall(ModuleData data)
        {
            if (_targetSlot == null)
                return false;

            if (!_targetSlot.IsAvailable())
                return false;

            if (data == null)
                return false;

            if (_targetSlot.SlotType != data.AllowedSlot)
                return false;

            GameObject prefab = data.AlivePrefab;

            if (prefab == null)
                return false;

            GameObject moduleObject = Instantiate(
                prefab,
                _targetSlot.transform.position,
                Quaternion.identity,
                _targetSlot.transform
            );

            ModuleRuntime runtime = moduleObject.GetComponent<ModuleRuntime>();

            if (runtime == null)
            {
                Destroy(moduleObject);
                return false;
            }

            runtime.Data = data;

            _targetSlot.Install(runtime);

            Close();

            return true;
        }

        public void OnSlotPointerEnter()
        {
            _pointerOverSlot = true;
        }

        public void OnSlotPointerExit()
        {
            _pointerOverSlot = false;
            TryClose();
        }

        public void OnShopPointerEnter()
        {
            _pointerOverShop = true;
        }

        public void OnShopPointerExit()
        {
            _pointerOverShop = false;
            TryClose();
        }

        private void TryClose()
        {
            if (!_pointerOverSlot && !_pointerOverShop)
                Close();
        }
    }
}