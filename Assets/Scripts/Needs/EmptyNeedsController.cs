using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Needs
{
    [AddComponentMenu("Sunflower/Needs/Empty Need Controller")]
    public class EmptyNeedsController : MonoBehaviour
    {
        [Header("Needs")]
        [SerializeField] private List<Need> _needs = new();

        private List<Need> _emptyNeeds = new();

        public IReadOnlyList<Need> EmptyNeeds { get => _emptyNeeds; }

        public event System.Action OnEmptyAdded;
        public event System.Action OnEmptyRemoved;

        private void OnEnable()
        {
            foreach (var need in _needs)
            {
                need.OnValueChanged += OnValueChanged;
                need.OnNeedEmpty += OnEmpty;
            }
        }

        private void OnDisable()
        {
            foreach (var need in _needs)
            {
                need.OnValueChanged -= OnValueChanged;
                need.OnNeedEmpty -= OnEmpty;
            }
        }

        private void OnEmpty(Need sender)
        {
            if (!_emptyNeeds.Contains(sender))
            {
                _emptyNeeds.Add(sender);
                OnEmptyAdded?.Invoke();
            }
        }

        private void OnValueChanged(Need sender, float value)
        {
            if (_emptyNeeds.Contains(sender) && value != 0f)
            {
                _emptyNeeds.Remove(sender);
                OnEmptyRemoved?.Invoke();
            }
        }
    }
}