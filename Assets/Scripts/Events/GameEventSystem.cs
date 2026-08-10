using System.Collections.Generic;
using Sunflower.Modifiers;
using Sunflower.Needs;
using UnityEngine;

namespace Sunflower.Event
{
    public class GameEventSystem : MonoBehaviour
    {
        [SerializeField] private NeedSystem _targetNeedSystem;

        public event System.Action<GameEventData> OnEventStarted;
        public event System.Action<GameEventData> OnEventEnded;

        private class ActiveGameEvent
        {
            public GameEventData Data;
            public float remainingTime;
        }

        private readonly List<ActiveGameEvent> _activeEvents = new List<ActiveGameEvent>();

        public void StartEvent(GameEventData eventData)
        {
            if (eventData == null)
                return;

            _activeEvents.Add(new ActiveGameEvent
            {
                Data = eventData,
                remainingTime = eventData.duration
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

                activeEvent.remainingTime -= Time.deltaTime;

                if (activeEvent.remainingTime <= 0f)
                {
                    GameEventData Data = activeEvent.Data;

                    _activeEvents.RemoveAt(i);

                    OnEventEnded?.Invoke(Data);
                }
            }
        }

    }
}