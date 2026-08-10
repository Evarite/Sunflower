using System.Collections.Generic;
using Sunflower.Enemies;
using Sunflower.Modifiers;
using UnityEngine;

namespace Sunflower.Enemies
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Sunflower/Enemies/Enemy")]
    public class EnemyData : ScriptableObject
    {
        public string enemyName = "Enemy";

        public float maxHp = 10f;
        //public float damage = 1f;
        public ModifierData damageModifier;
        public float attackInterval = 1f;
        public float detectionRadius = 3f;
        public float attackRange = 1f;
        public float moveSpeed = 1f;

        public virtual EnemyBehaviorType Behavior => EnemyBehaviorType.Aggressive;

        [Tooltip("Слой, на котором лежат цели")]
        public LayerMask targetMask = ~0;
    }
}
