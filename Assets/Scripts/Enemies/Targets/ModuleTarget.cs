using System;
using UnityEngine;

namespace Sunflower.Enemies
{
    [RequireComponent (typeof (BoxCollider2D) )]
    public class ModuleTarget : MonoBehaviour, ITargetable
    {
        [SerializeField] private float _priority = 10f;
        [SerializeField] private float _maxHp = 10f;

        public float Hp { get; private set; }

        public float Priority => _priority;
        public bool IsAlive => Hp > 0f;
        public Transform TargetTransform => transform;

        public event Action<ModuleTarget> OnDestroyed;

        private void Awake()
        {
            Hp = _maxHp;
        }

        public void ReceiveAttack(float damage, Enemy attacker)
        {
            if (!IsAlive)
                return;

            Hp -= damage;

            if (Hp <= 0f)
            {
                OnDestroyed?.Invoke(this);
                gameObject.SetActive(false);
            }
        }
    }
}
