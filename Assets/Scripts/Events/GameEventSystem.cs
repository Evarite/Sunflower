using Sunflower.Modifiers;
using Sunflower.Needs;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Event
{
    public class GameEventSystem : MonoBehaviour
    {

        public event System.Action<GameEventDefinition> EventStarted;
        public event System.Action<GameEventDefinition> EventEnded;

        public class ActiveGameEvent
        {
            private GameEventDefinition _data;
            private float _remainingTime;

            public GameEventDefinition Data { get => _data; set => _data = value; }
            public float RemainingTime { get => _remainingTime; set => _remainingTime = value; }
        }

        private List<ActiveGameEvent> _activeEvents = new();

        public List<ActiveGameEvent> ActiveEvents { get => _activeEvents; set => _activeEvents = value; }

        private void Update()
        {
            for (int i = _activeEvents.Count - 1; i >= 0; i--)
            {
                ActiveGameEvent activeEvent = _activeEvents[i];

                if (activeEvent.Data.duration <= 0f)
                    continue;

                activeEvent.RemainingTime -= Time.deltaTime;

                if (activeEvent.RemainingTime <= 0f)
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
                RemainingTime = Data.duration
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

                    if (modifier.type == ModifierType.Add)
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