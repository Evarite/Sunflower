using UnityEngine;

namespace Sunflower.Needs
{
    [AddComponentMenu("Sunflower/Needs/Need")]
    public class Need : MonoBehaviour
    {
        [SerializeField] private float _value = 0f;

        [Tooltip("Максимальное значение зоны недостатка ресурса")]
        [SerializeField] private float _lackMaxValue = 0.3f;
        [Tooltip("Минимальное значение оптимальной зоны ресурса")]
        [SerializeField] private float _optimalMinValue = 0.7f;

        private void Awake() => OnValueChanged?.Invoke(this, _value);

        public float Value
        {
            get => _value;
            set
            {
                _value = Mathf.Clamp01(value);
                OnValueChanged?.Invoke(this, _value);

                if (_value == 0f)
                    OnNeedEmpty?.Invoke(this);
            }
        }

        public float LackMaxValue { get => _lackMaxValue; set => _lackMaxValue = value; }
        public float OptimalMinValue { get => _optimalMinValue; set => _optimalMinValue = value; }

        public event System.Action<Need, float> OnValueChanged;
        public event System.Action<Need> OnNeedEmpty;
    }
}