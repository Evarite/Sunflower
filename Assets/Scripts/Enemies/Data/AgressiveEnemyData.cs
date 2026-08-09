using UnityEngine;

namespace Sunflower.Enemies
{
    [CreateAssetMenu(fileName = "PassiveEnemy", menuName = "Sunflower/Enemies/Agressive Enemy")]
    public class AgressiveEnemyData : EnemyData
    {

        public override EnemyBehaviorType Behavior => EnemyBehaviorType.Aggressive;
    }
}
