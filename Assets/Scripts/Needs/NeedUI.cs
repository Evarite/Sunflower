using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.Needs
{
    [RequireComponent(typeof(Slider))]
    [AddComponentMenu("Sunflower/Needs/Need Slider UI")]
    public class NeedUI : MonoBehaviour
    {
        [SerializeField] private Need _need;

        private Slider _slider;

        private void Awake() => _slider = GetComponent<Slider>();

        private void OnEnable() => _need.OnValueChanged += OnValueChanged;

        private void OnDisable() => _need.OnValueChanged -= OnValueChanged;

        private void OnValueChanged(float value) => _slider.value = value;
    }
}