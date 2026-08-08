using UnityEngine;

namespace Sunflower.Needs
{
    public class Need : MonoBehaviour
    {
        private float _value = 0f;

        public float Value
        {
            get => _value;
            set
            {
                _value = Mathf.Clamp01(value);
                OnValueChanged?.Invoke(_value);
            }
        }

        public event System.Action<float> OnValueChanged;
    }
}