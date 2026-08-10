using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Growth
{
    [AddComponentMenu("Sunflower/Growth/Sunflower Growth")]
    public class SunflowerGrowth : MonoBehaviour
    {
        [SerializeField] private float _growthSpeed = 1f;
        [SerializeField] private float _scaleRatio = 0.1f;

        [SerializeField] private StopOnEnemy _stop;

        private List<float> _modifiers = new();

        private float _height = 0f;

        private Vector3 _startPos;
        private Vector3 _startScale;

        public float Height { get => _height; set => _height = value; }
        public List<float> Modifiers => _modifiers;

        public float Speed { get; private set; }

        private void Awake()
        {
            _startPos = transform.position;
            _startScale = transform.localScale;
        }

        private void Update()
        {
            if (_stop.HasEnemiesInView())
                return;

            float modifier = 1f;
            foreach (var mod in Modifiers)
                modifier *= mod;

            Speed = _growthSpeed * modifier;

            _height += Speed * Time.deltaTime;
            transform.position = _startPos + new Vector3(0, _height, 0);
            transform.localScale =
                _startScale + new Vector3(_height * _scaleRatio, _height * _scaleRatio, 0);
        }
    }
}