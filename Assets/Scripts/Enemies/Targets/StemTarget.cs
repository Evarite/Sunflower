using System.Collections.Generic;
using Sunflower.Enemies;
using Sunflower.Modifiers;
using Sunflower.Modules;
using Sunflower.Needs;
using UnityEngine;
namespace Sunflower.Enemies
{
    [RequireComponent(typeof(BoxCollider2D)), RequireComponent(typeof(NeedComponent))]
    public class StemTarget : MonoBehaviour, ITargetable
    {
        [SerializeField] private float _priority = 1f;
        [SerializeField] private float _resourceDamageMultiplier = 10f;
        [SerializeField] private List<Need> _needs = new List<Need>();

        public float Priority => _priority;
        public bool IsAlive => _needs.Count > 0;
        public Transform TargetTransform => transform;

        public void ReceiveAttack(ModifierData damageModifier, Enemy attacker)
        {
            if (NeedSystem.Instance == null)
                return;
            if (damageModifier == null)
                return;

            NeedSystem.Instance.ApplyModifier(damageModifier, attacker);



        }
    }
}