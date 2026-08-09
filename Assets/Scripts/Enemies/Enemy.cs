using System;
using Sunflower.Enemies;
using UnityEngine;

namespace Sunflower.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private EnemyData _data;

        public EnemyData Data => _data;

        public float Hp { get; private set; }

        public bool IsProvoked { get; private set; }

        public bool IsDead => Hp <= 0f;

        public event Action<Enemy> OnDied;
        public event Action<Enemy> OnDespawned;
        public event Action<ITargetable> OnAttackPerformed;

        private float _attackTimer;
        private float _despawnTimer;
        private float _retargetTimer;
        private ITargetable _currentTarget;
        private const float RetargetInterval = 0.2f;

        private void Awake()
        {
            if (_data != null)
                Initialize(_data);
        }

        public void Initialize(EnemyData data)
        {
            _data = data;
            Hp = data.maxHp;
            if (data is PassiveEnemyData passiveEnemyData)
                _despawnTimer = passiveEnemyData.passiveLifetime;
        }

        private void Update()
        {
            UpdateDespawn();
            UpdateCombat();
        }

        private void UpdateDespawn()
        {
            if (_data.behavior != EnemyBehaviorType.Passive)
                return;

            if (IsProvoked)
                return;

            _despawnTimer -= Time.deltaTime;

            if (_despawnTimer <= 0f)
                Despawn();
        }

        private void UpdateCombat()
        {
            if (!CanAct())
                return;

            _retargetTimer -= Time.deltaTime;

            if (_retargetTimer <= 0f)
            {
                _retargetTimer = RetargetInterval;
                _currentTarget = FindBestTarget();
            }

            if (_currentTarget == null)
                return;

            float distance = Vector3.Distance(
                transform.position,
                _currentTarget.TargetTransform.position
            );

            if (distance > _data.attackRange)
            {
                MoveTowards(_currentTarget.TargetTransform);
            }
            else
            {
                TryAttack();
            }
        }


        private bool CanAct()
        {
            return _data.behavior == EnemyBehaviorType.Aggressive || IsProvoked;
        }


        private void MoveTowards(Transform target)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                _data.moveSpeed * Time.deltaTime
            );
        }

        private void TryAttack()
        {
            _attackTimer -= Time.deltaTime;

            if (_attackTimer > 0f)
                return;

            _attackTimer = _data.attackInterval;

            _currentTarget.ReceiveAttack(_data.damage, this);
            OnAttackPerformed?.Invoke(_currentTarget);
        }

        private ITargetable FindBestTarget()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(
                transform.position,
                _data.detectionRadius,
                _data.targetMask
            );

            ITargetable best = null;

            foreach (Collider2D hit in hits)
            {
                if (!hit.TryGetComponent<ITargetable>(out ITargetable target))
                    continue;

                if (!target.IsAlive)
                    continue;

                if (best == null || target.Priority > best.Priority)
                    best = target;
            }

            return best;
        }

        public void TakeDamage(float damage)
        {
            if (IsDead)
                return;

            Hp -= damage;
            IsProvoked = true;

            if (IsDead)
                Die();
        }

        private void Die()
        {
            OnDied?.Invoke(this);
            Destroy(gameObject);
        }

        private void Despawn()
        {
            OnDespawned?.Invoke(this);
            Destroy(gameObject);
        }

        private void OnDrawGizmosSelected()
        {
            if (_data == null)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _data.detectionRadius);
        }
    }
}
