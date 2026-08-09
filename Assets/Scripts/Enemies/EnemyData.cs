using Sunflower.Enemies;
using UnityEngine;

namespace Sunflower.Enemies
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Sunflower/Enemy")]
    public class EnemyData : ScriptableObject
    {
        public string enemyName = "Enemy";

        public float maxHp = 10f;
        public float damage = 1f;
        public float attackInterval = 1f;
        public float detectionRadius = 3f;
        public float attackRange = 1f;
        public float moveSpeed = 1f;

        public EnemyBehaviorType behavior = EnemyBehaviorType.Aggressive;

        [Tooltip("Слой, на котором лежат цели")]
        public LayerMask targetMask = ~0;
    }
}
