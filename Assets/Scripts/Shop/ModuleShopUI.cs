using Sunflower.Modules;
using Sunflower.ModuleSlot;
using Sunflower.Seeds;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sunflower.Shop
{
    [AddComponentMenu("Sunflower/Shop/Module Shop UI")]
    public class ModuleShopUI : MonoBehaviour
    {
        public static ModuleShopUI Instance { get; private set; }

        [Header("Shop Panels")]
        [SerializeField] private GameObject _stemShopPanel;
        [SerializeField] private GameObject _environmentShopPanel;

        private Slot _targetSlot;

        public Slot TargetSlot => _targetSlot;

        private GameObject ActiveShopPanel
        {
            get
            {
                if (_stemShopPanel != null &&
                    _stemShopPanel.activeSelf)
                {
                    return _stemShopPanel;
                }

                if (_environmentShopPanel != null &&
                    _environmentShopPanel.activeSelf)
                {
                    return _environmentShopPanel;
                }

                return null;
            }
        }

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

        private void Update()
        {
            if (_targetSlot == null)
                return;

            GameObject activePanel = ActiveShopPanel;

            if (activePanel == null)
                return;

            if (IsPointerOverSlot() || IsPointerOverShop())
                return;

            Close();
        }

        public void Open(Slot slot)
        {
            if (slot == null)
                return;

            if (!slot.IsAvailable())
                return;

            _targetSlot = slot;

            OpenShopForSlot(slot);

            PositionShop();
        }

        public void Close()
        {
            _targetSlot = null;

            if (_stemShopPanel != null)
                _stemShopPanel.SetActive(false);

            if (_environmentShopPanel != null)
                _environmentShopPanel.SetActive(false);
        }

        public bool TryInstall(ModuleData moduleData, int cost)
        {
            if (SeedsCounter.Value < cost)
                return false;

            if (_targetSlot == null)
                return false;

            if (moduleData == null)
                return false;

            bool installed =
                _targetSlot.TryInstall(moduleData);

            if (!installed)
                return false;

            Close();

            SeedsCounter.Value -= cost;

            return true;
        }

        private void OpenShopForSlot(Slot slot)
        {
            if (_stemShopPanel != null)
                _stemShopPanel.SetActive(false);

            if (_environmentShopPanel != null)
                _environmentShopPanel.SetActive(false);

            switch (slot.SlotType)
            {
                case SlotType.Stem:

                    if (_stemShopPanel != null)
                        _stemShopPanel.SetActive(true);

                    break;

                case SlotType.Environment:

                    if (_environmentShopPanel != null)
                        _environmentShopPanel.SetActive(true);

                    break;
            }
        }

        private void PositionShop()
        {
            GameObject activePanel = ActiveShopPanel;

            if (activePanel == null)
                return;

            if (_targetSlot == null)
                return;

            RectTransform panel =
                activePanel.GetComponent<RectTransform>();

            if (panel == null)
                return;

            Canvas canvas =
                activePanel.GetComponentInParent<Canvas>();

            if (canvas == null)
                return;

            Camera camera = Camera.main;

            if (camera == null)
                return;

            Vector2 screenPosition =
                camera.WorldToScreenPoint(
                    _targetSlot.transform.position
                );

            RectTransform canvasRect =
                canvas.GetComponent<RectTransform>();

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                screenPosition,
                canvas.renderMode ==
                RenderMode.ScreenSpaceOverlay
                    ? null
                    : canvas.worldCamera,
                out Vector2 localPosition
            );

            panel.localPosition = localPosition;
        }

        private bool IsPointerOverSlot()
        {
            if (_targetSlot == null)
                return false;

            if (Mouse.current == null)
                return false;

            Camera camera = Camera.main;

            if (camera == null)
                return false;

            Vector2 mousePosition =
                camera.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue()
                );

            Collider2D collider =
                _targetSlot.GetComponent<Collider2D>();

            if (collider == null)
                return false;

            return collider.OverlapPoint(mousePosition);
        }

        private bool IsPointerOverShop()
        {
            GameObject activePanel = ActiveShopPanel;

            if (activePanel == null)
                return false;

            if (Mouse.current == null)
                return false;

            RectTransform panel =
                activePanel.GetComponent<RectTransform>();

            if (panel == null)
                return false;

            Canvas canvas =
                activePanel.GetComponentInParent<Canvas>();

            if (canvas == null)
                return false;

            Camera camera =
                canvas.renderMode ==
                RenderMode.ScreenSpaceOverlay
                    ? null
                    : canvas.worldCamera;

            return RectTransformUtility.RectangleContainsScreenPoint(
                panel,
                Mouse.current.position.ReadValue(),
                camera
            );
        }
    }
}