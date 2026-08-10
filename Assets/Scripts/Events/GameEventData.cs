using UnityEngine;
using System.Collections.Generic;
using Sunflower.Modifiers;

namespace Sunflower.Event
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Sunflower/Game Event")]
    public class GameEventData : ScriptableObject
    {
        [Header("Название ивента")]
        public string eventName;

        [Header("Сколько длиться ивент (секунд)")]
        public float duration = 10f;

        [SerializeField]
        [Header("Список модификаторов к ресурсам")]
        public List<ModifierData> modifiers = new List<ModifierData>();
    }
}

