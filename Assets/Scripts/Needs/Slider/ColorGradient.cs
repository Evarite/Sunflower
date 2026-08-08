using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.Needs.SliderUI
{
    [AddComponentMenu("Sunflower/Needs/SliderUI/Color Gradient")]
    [RequireComponent(typeof(Slider))]
    public class ColorGradient : MonoBehaviour
    {
        [Header("Fill Area")]
        [SerializeField] private Image _fillArea;

        [Header("Colors")]
        [SerializeField] private Color _lackColor = Color.red;
        [SerializeField] private Color _normalColor;

        [Header("Need")]
        [SerializeField] private Need _need;

        //private Slider _slider;

        //private void Awake() => _slider = GetComponent<Slider>();

        private void OnEnable() => _need.OnValueChanged += RefreshColor;

        private void OnDisable() => _need.OnValueChanged -= RefreshColor;

        private void RefreshColor(Need sender, float value) =>
            _fillArea.color = Color.Lerp(_lackColor, _normalColor, value);
    }
}