using System;
using Sunflower.Needs;
using UnityEngine;

namespace Sunflower.Modifiers
{
    [CreateAssetMenu(fileName = "New Modifier", menuName = "Sunflower/Modifiers/Modifier Data")]
    public class ModifierData: ScriptableObject
   {
        public NeedData need;
        public ModifierType type;
        public float value = 1f;

        [Tooltip("Для AddRate/MultiplyRate. <= 0 означает постоянно. Для AddValue игнорируется.")]
        public float duration;

        [NonSerialized]
        public UnityEngine.Object source;

        public ModifierData(NeedData need, ModifierType type, float value, float duration, UnityEngine.Object source)
        {
            this.need = need;
            this.type = type;
            this.value = value;
            this.duration = duration;
            this.source = source;
        }

        static public ModifierData CreateMultipliedModifierData(ModifierData other , float multiplier)
        {

            return new ModifierData(
                other.need,
                other.type,
                other.value*multiplier,
                other.duration,
                other.source
            );

        }
    }
}