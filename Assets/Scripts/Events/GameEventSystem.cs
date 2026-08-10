using System.Collections.Generic;
using Sunflower.Modifiers;
using Sunflower.Needs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sunflower.Event
{
    public class GameEventSystem : MonoBehaviour
    {
        [SerializeField] private List<GameEventData> _eventDatas = new();

        [SerializeField] private NeedSystem _targetNeedSystem;

        public event System.Action<GameEventData> OnEventStarted;
        public event System.Action<GameEventData> OnEventEnded;

        private class ActiveGameEvent
        {
            private GameEventData _data;
            private float _remainingTime;

            public GameEventData Data { get => _data; set => _data = value; }
            public float RemainingTime { get => _remainingTime; set => _remainingTime = value; }
        }

        private List<ActiveGameEvent> _activeEvents = new List<ActiveGameEvent>();

        public void StartEvent(GameEventData eventData)
        {
            if (eventData == null)
                return;

            _activeEvents.Add(new ActiveGameEvent
            {
                Data = eventData,
                RemainingTime = eventData.duration
            });

            foreach (ModifierData modifierData in eventData.modifiers)
            {
                _targetNeedSystem.ApplyModifier(modifierData, this);
            }
            OnEventStarted?.Invoke(eventData);
        }

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
                    GameEventData Data = activeEvent.Data;

                    _activeEvents.RemoveAt(i);

                    OnEventEnded?.Invoke(Data);
                }
            }
        }

        

        public float ApplyModifiers(NeedData need, float baseValue)
        {
            float additive = 0f;
            float multiplier = 1f;

            foreach (ActiveGameEvent activeEvent in _activeEvents)
            {
                foreach (ModifierData modifier in activeEvent.Data.modifiers)
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

        public GameEventData GetEventData(string eventId)
        {
            return _eventDatas.Find(
                x => x.EventId == eventId
            );
        }

        public void RestoreEvent(GameEventData data, float remainingTime)
        {
            if (data == null)
                return;

            _activeEvents.Add(new ActiveGameEvent
            {
                Data = data,
                RemainingTime = remainingTime
            });

            OnEventStarted?.Invoke(data);
        }
    }
}