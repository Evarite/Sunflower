using Sunflower.Growth;
using UnityEngine;

namespace Sunflower.CameraSystem
{
    [RequireComponent(typeof(Camera))]
    public class CameraZoomOut : MonoBehaviour
    {
        [SerializeField] private float _ratio;
        [SerializeField] private SunflowerGrowth _sunflowerGrowth;

        private Camera _camera;

        private void Awake() => _camera = GetComponent<Camera>();

        private void LateUpdate() => _camera.orthographicSize +=
            _sunflowerGrowth.Speed * _ratio * Time.deltaTime;

        public float Save() => _camera.orthographicSize;

        public void Load(float value) => _camera.orthographicSize = value;
    }
}