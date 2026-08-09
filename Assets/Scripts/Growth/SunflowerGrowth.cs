using UnityEngine;

namespace Sunflower.Growth
{
    [AddComponentMenu("Sunflower/Growth/Sunflower Growth")]
    public class SunflowerGrowth : MonoBehaviour
    {
        [SerializeField] private float _growthSpeed = 1f;
        [SerializeField] private float _scaleRatio = 0.1f;

        private float _height = 0f;

        private Vector3 _startPos;
        private Vector3 _startScale;

        public float Height { get => _height; }

        private void Awake()
        {
            _startPos = transform.position;
            _startScale = transform.localScale;
        }

        private void Update()
        {
            _height += _growthSpeed * Time.deltaTime;
            transform.position = _startPos + new Vector3(0, _height, 0);
            transform.localScale =
                _startScale + new Vector3(_height * _scaleRatio, _height * _scaleRatio, 0);
        }
    }
}