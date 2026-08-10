using System.Collections.Generic;
using Sunflower.Enemies;
using Sunflower.Needs;
using UnityEngine;
namespace Sunflower.Enemies
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class StemTarget : MonoBehaviour, ITargetable
    {
        [SerializeField] private float _priority = 1f;
        [SerializeField] private float _resourceDamage = 0.05f;
        [SerializeField] private List<Need> _needs = new List<Need>();

        public float Priority => _priority;
        public bool IsAlive => _needs.Count > 0;
        public Transform TargetTransform => transform;

        private void Awake()
        {
            if (_needs.Count == 0)
                _needs.AddRange(GetComponentsInChildren<Need>(true));
        }

        public void ReceiveAttack(float damage, Enemy attacker)
        {
            float loss = _resourceDamage * damage;

            foreach (Need need in _needs)
            {
                if (need == null)
                    continue;

                need.CurrentValue -= loss;
            }
        }
    }
}