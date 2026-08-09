using Sunflower.ModuleSlot;
using UnityEngine;

namespace Sunflower.Modules
{
    public abstract class Module : MonoBehaviour
    {
        [SerializeField] protected ModuleData _data;
        [SerializeField] protected Slot _slot;
        [SerializeField] protected float _currentHealth;

        public ModuleData Data { get => _data; }
        public Slot Slot { get => _slot; }
        public float CurrentHealth { get => _currentHealth; }

        protected virtual void Awake() => _currentHealth = _data.MaxHealth;

        public virtual void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0f)
                Die();
        }

        protected virtual void Die() => Destroy(gameObject);
    }
}