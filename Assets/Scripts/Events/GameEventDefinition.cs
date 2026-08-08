using UnityEngine;
using System.Collections.Generic;
using Sunflower.Modifiers;

namespace Sunflower.Event
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Game/Game Event")]
    public class GameEventDefinition : ScriptableObject
    {
        [Header("Название ивента")]
        public string eventName;

        [Header("Сколько длиться ивент (секунд)")]
        public float duration = 10f;

        [SerializeField]
        [Header("Список модификаторов к ресурсам")]
        public List<StatModifier> modifiers = new List<StatModifier>();
    }
}

