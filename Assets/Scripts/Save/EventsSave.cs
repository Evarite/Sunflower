using Sunflower.Event;
using Sunflower.SaveSystem.Data;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [AddComponentMenu("Sunflower/Save/Events Save")]
    public class EventsSave : MonoBehaviour
    {
        [SerializeField] private GameEventSystem _gameEventSystem;

        public EventsSaveData Save()
        {
            var activeEvents = _gameEventSystem.ActiveEvents;
            var eventsSaveData = new EventsSaveData();

            foreach (var gameEvent in activeEvents)
            {
                var eventData = new EventData(gameEvent.Data.eventName, gameEvent.RemainingTime);
                eventsSaveData.Events.Add(eventData);
            }

            return eventsSaveData;
        }
    }
}
