using Sunflower.Modifiers;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Event
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Sunflower/Game Event")]
    public class GameEventDefinition : ScriptableObject
    {
        [Header("Название ивента")]
        public string eventName;

        [Header("Сколько длится ивент (секунд)")]
        public float duration = 10f;

        [SerializeField]
        [Header("Список модификаторов к ресурсам")]
        public List<StatModifier> modifiers = new List<StatModifier>();
    }
}

