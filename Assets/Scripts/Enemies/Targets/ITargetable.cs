using System.Collections.Generic;
using Sunflower.Modifiers;
using UnityEngine;

namespace Sunflower.Enemies
{
    public interface ITargetable
    {
        float Priority { get; }
        bool IsAlive { get; }
        Transform TargetTransform { get; }

        void ReceiveAttack(ModifierData damageModifier, Enemy attacker);
    }
}
