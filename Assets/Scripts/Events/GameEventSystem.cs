using Sunflower.Modifiers;
using Sunflower.Needs;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Event
{
    public class GameEventSystem : MonoBehaviour
    {
        private List<GameEventData> _eventDefinitions = new();
        
        [SerializeField] private NeedSystem _targetNeedSystem;

        public event System.Action<GameEventData> OnEventStarted;
        public event System.Action<GameEventData> OnEventEnded;

        public class ActiveGameEvent
        {
            private GameEventData _data;
            private float _remainingTime;

            public GameEventData Data { get => _data; set => _data = value; }
            public float RemainingTime { get => _remainingTime; set => _remainingTime = value; }
        }

        private List<ActiveGameEvent> _activeEvents = new();

        public List<ActiveGameEvent> ActiveEvents { get => _activeEvents; set => _activeEvents = value; }

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
                _targetNeedSystem.ApplyModifier(modifierData,this);
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

        public GameEventData GetEventData(string eventId)
        {
            return _eventDefinitions.Find(
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