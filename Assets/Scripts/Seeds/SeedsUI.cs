using TMPro;
using UnityEngine;

namespace Sunflower.Seeds
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SeedsUI : MonoBehaviour
    {
        TextMeshProUGUI _text;

        private void Awake() => _text = GetComponent<TextMeshProUGUI>();

        private void OnEnable() => SeedsCounter.OnValueChanged += OnValueChanged;

        private void OnDisable() => SeedsCounter.OnValueChanged -= OnValueChanged;

        private void OnValueChanged(int value) => _text.text = value.ToString();
    }
}