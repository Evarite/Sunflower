using UnityEngine;

namespace Sunflower.Enemies
{
    public interface ITargetable
    {
        float Priority { get; }
        bool IsAlive { get; }
        Transform TargetTransform { get; }

        void ReceiveAttack(float damage, Enemy attacker);
    }
}
