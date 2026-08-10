using Sunflower.Event;
using Sunflower.SaveSystem.Data;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [AddComponentMenu("Sunflower/Save/Events Save")]
    public class EventsSave : MonoBehaviour
    {
        [SerializeField] private GameEventSystem _gameEventSystem;

        public EventsSaveData GetSaveData()
        {
            var eventsSaveData = new EventsSaveData();

            foreach (var gameEvent in _gameEventSystem.ActiveEvents)
            {
                var eventData = new EventData(
                    gameEvent.Data.EventId,
                    gameEvent.RemainingTime
                );

                eventsSaveData.Events.Add(eventData);
            }

            return eventsSaveData;
        }

        public void ApplySaveData(EventsSaveData data)
        {
            if (data == null)
                return;

            foreach (var eventData in data.Events)
            {
                GameEventData definition =
                    _gameEventSystem.GetEventData(eventData.EventId);

                if (definition == null)
                {
                    Debug.LogWarning(
                        $"Could not find GameEventDefinition with ID '{eventData.EventId}'."
                    );

                    continue;
                }

                _gameEventSystem.RestoreEvent(
                    definition,
                    eventData.RemainingTime
                );
            }
        }
    }
}