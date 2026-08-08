using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Needs
{
    public class EmptyNeedsController : MonoBehaviour
    {
        [SerializeField] private List<Need> _needs = new();

        private List<Need> _emptyNeeds = new();

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
                _emptyNeeds.Add(sender);
        }

        private void OnValueChanged(Need sender, float value)
        {
            if (_needs.Contains(sender) && value != 0f)
                _emptyNeeds.Remove(sender);
        }
    }
}