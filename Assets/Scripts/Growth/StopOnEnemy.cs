using UnityEngine;

namespace Sunflower.Growth
{
    [RequireComponent(typeof(Camera))]
    public class StopOnEnemy : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyLayer;

        private Camera _camera;

        private void Awake() => _camera = GetComponent<Camera>();

        public bool HasEnemiesInView()
        {
            Vector2 center = _camera.transform.position;

            Vector2 size = new Vector2(
                _camera.orthographicSize * 2f * _camera.aspect,
                _camera.orthographicSize * 2f
            );

            return Physics2D.OverlapBox(
                center,
                size,
                _camera.transform.eulerAngles.z,
                _enemyLayer
            ) != null;
        }
    }
}