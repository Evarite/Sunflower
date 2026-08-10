using Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;

namespace Sunflower.Modules
{
    public class TurretModule : ModuleRuntime
    {
        [SerializeField] private float _shootCooldown = 1f;
        [SerializeField] private GameObject _bulletPrefab;

        protected override void Start() => StartCoroutine(Shoot());

        private GameObject GetNearestEnemy()
        {
            var enemies = EnemiesSpawnManager.Instance.ActiveEnemies;

            if (enemies == null || enemies.Count == 0)
                return null;

            GameObject nearestEnemy = null;
            float minDist = float.MaxValue;

            foreach (var enemy in enemies)
            {
                if (enemy == null)
                    continue;

                float dist = (transform.position - enemy.transform.position).sqrMagnitude;

                if (dist < minDist)
                {
                    minDist = dist;
                    nearestEnemy = enemy;
                }
            }

            return nearestEnemy;
        }

        private Quaternion GetRotation(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
                GameObject target = GetNearestEnemy();

                if (target != null)
                {
                    Vector3 direction = target.transform.position - transform.position;
                    Quaternion rotation = GetRotation(direction);

                    Instantiate(_bulletPrefab, transform.position, rotation);
                }

                ApplyActiveModifiers();

                yield return new WaitForSeconds(_shootCooldown);
            }
        }
    }
}