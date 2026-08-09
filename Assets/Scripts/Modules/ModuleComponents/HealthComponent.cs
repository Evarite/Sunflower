using System;
using Sunflower.Enemies;
using UnityEngine;

namespace Sunflower.Modules.Components
{
    [CreateAssetMenu(fileName = "New Component", menuName = "Sunflower/Modules Components/Health Component")]
    public class HealthComponent : MonoBehaviour, ITargetable
    { 
        [SerializeField] private float _maxHealth = 10f;
        [SerializeField] private float _priority = 10f;

        private float _currentHealth;
        public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

        public float MaxHealth => _maxHealth;
        public float HealthPercent => CurrentHealth / MaxHealth;

        public float Priority => _priority;
        public bool IsAlive => CurrentHealth > 0f;
        public Transform TargetTransform => transform;

        public event Action<float> OnDamaged;
        public event Action OnDestroyed;

        public void ReceiveAttack(float damage, Enemy attacker)
        {
            if (!IsAlive) return;

            _currentHealth -= damage;

            // TODO: эффект попадания, аггро к attacker, проверка смерти
            if (!IsAlive)
            {
                // TODO: логика смерти
            }
        }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

    }
}

