using System.Collections.Generic;
using Sunflower.Modifiers;
using Sunflower.Needs;
using UnityEngine;

namespace Sunflower.Event
{
    public class GameEventSystem : MonoBehaviour
    {

        public event System.Action<GameEventDefinition> EventStarted;
        public event System.Action<GameEventDefinition> EventEnded;

        private class ActiveGameEvent
        {
            public GameEventDefinition Data;
            public float remainingTime;
        }

        private readonly List<ActiveGameEvent> _activeEvents = new List<ActiveGameEvent>();

        private void Update()
        {
            for (int i = _activeEvents.Count - 1; i >= 0; i--)
            {
                ActiveGameEvent activeEvent = _activeEvents[i];

                if (activeEvent.Data.duration <= 0f)
                    continue;

                activeEvent.remainingTime -= Time.deltaTime;

                if (activeEvent.remainingTime <= 0f)
                {
                    GameEventDefinition Data = activeEvent.Data;

                    _activeEvents.RemoveAt(i);

                    EventEnded?.Invoke(Data);
                }
            }
        }

        public void StartEvent(GameEventDefinition Data)
        {
            if (Data == null)
                return;

            _activeEvents.Add(new ActiveGameEvent
            {
                Data = Data,
                remainingTime = Data.duration
            });

            EventStarted?.Invoke(Data);
        }

        public float ApplyModifiers(NeedId need, float baseValue)
        {
            float additive = 0f;
            float multiplier = 1f;

            foreach (ActiveGameEvent activeEvent in _activeEvents)
            {
                foreach (StatModifier modifier in activeEvent.Data.modifiers)
                {
                    if (modifier.need != need)
                        continue;

                    if (modifier.type == ModifierType.AddValue)
                        additive += modifier.value;
                    else
                        multiplier *= modifier.value;
                }
            }

            multiplier = Mathf.Max(0f, multiplier);

            return (baseValue + additive) * multiplier;
        }
    }
}