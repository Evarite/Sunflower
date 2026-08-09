using UnityEngine;

namespace Sunflower.Enemies
{
    [CreateAssetMenu(fileName = "PassiveEnemy", menuName = "Sunflower/Enemies/Passive Enemy")]
    public class PassiveEnemyData : EnemyData
    {
        [Tooltip("Для Passive: сколько живёт, если его не атакуют")]
        public float passiveLifetime = 5f;

        public override EnemyBehaviorType Behavior => EnemyBehaviorType.Passive;

    }
}
