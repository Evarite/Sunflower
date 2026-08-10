using Sunflower.Enemies;
using UnityEngine;

namespace Sunflower.Modules
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _lifeTime = 2f;
        [SerializeField] private float _speed;

        private void Awake() => Destroy(gameObject, _lifeTime);

        private void Update() =>
            transform.position += transform.rotation * Vector3.right * _speed * Time.deltaTime;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}