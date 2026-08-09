using System;
using Sunflower.Needs;
using UnityEngine;

namespace Sunflower.Modifiers
{
   public class ModifierData: ScriptableObject
   {
        public NeedData need;
        public ModifierType type;
        public float value = 1f;

        [Tooltip("Для AddRate/MultiplyRate. <= 0 означает постоянно. Для AddValue игнорируется.")]
        public float duration;

        [NonSerialized]
        public UnityEngine.Object source;
    }
}