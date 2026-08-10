
using System;

namespace Sunflower.Modifiers
{
    [Serializable]
    public class ActiveModifier
    {
        public ModifierType type;
        public float value;
        public float duration;
        public UnityEngine.Object source;
    }
}