using System;
using Sunflower.Needs;
using UnityEngine;

namespace Sunflower.Modifiers
{
    [CreateAssetMenu(fileName = "New Modifier", menuName = "Sunflower/Modifiers/Modifier Data")]
    public class ModifierData : ScriptableObject
    {
        public NeedData need;
        public ModifierType type;
        public float value = 1f;

        [Tooltip("Äëÿ AddRate/MultiplyRate. <= 0 îçíà÷àåò ïîñòîÿííî. Äëÿ AddValue èãíîðèðóåòñÿ.")]
        public float duration;

        [NonSerialized]
        public UnityEngine.Object source;
    }
}