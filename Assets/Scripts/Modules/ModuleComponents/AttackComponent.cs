using System.Collections.Generic;
using Sunflower.Enemies;
using UnityEngine;

namespace Sunflower.Modules.Components
{

    [CreateAssetMenu(fileName = "New Component", menuName = "Sunflower/Modules Components/Attack Component")]
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private float _damage = 1f;
        [SerializeField] private float _attackInterval = 1f;
        [SerializeField] private float _attackRange = 3f;
        [SerializeField] private LayerMask _targetMask = ~0;

        [Tooltip("Требует ли ресурс для атаки")]
        [SerializeField] private Sunflower.Needs.Need _ammoNeed;
        [SerializeField] private float _ammoCostPerShot = 0.1f;

        private float _attackTimer;
        private Enemy _currentTarget;

        private void Update()
        {
            _attackTimer -= Time.deltaTime;

            if (_attackTimer > 0f)
                return;

            _attackTimer = _attackInterval;

            if (!CanAttack())
                return;

            Enemy target = FindBestTarget();

            if (target == null)
                return;

            if (_ammoNeed != null)
            {
                if (_ammoNeed.CurrentValue < _ammoCostPerShot)
                    return;

                _ammoNeed.CurrentValue -= _ammoCostPerShot;
            }

            target.TakeDamage(_damage);
        }

        private bool CanAttack()
        {
            return true; // можно добавить проверку "достаточно ли HP" и т.д.
        }

        private Enemy FindBestTarget()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(
                transform.position,
                _attackRange,
                _targetMask
            );

            Enemy best = null;
            float bestDistance = float.MaxValue;

            foreach (Collider2D hit in hits)
            {
                if (!hit.TryGetComponent<Enemy>(out Enemy enemy))
                    continue;

                if (enemy.IsDead)
                    continue;

                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    best = enemy;
                }
            }

            return best;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _attackRange);
        }
    }
}