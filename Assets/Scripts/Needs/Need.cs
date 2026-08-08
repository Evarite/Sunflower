using UnityEngine;

namespace Sunflower.Needs
{
    public class Need : MonoBehaviour
    {
        private float _value = 0f;

        public float Value { get => _value; set => _value = value; }
    }
}