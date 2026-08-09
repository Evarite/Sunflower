using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SaveSystem.Data
{
    [System.Serializable]
    public class EventsSaveData
    {
        [SerializeField] private List<EventData> events = new();

        public List<EventData> Events => events;
    }

    [System.Serializable]
    public class EventData
    {
        [SerializeField] private string _eventId;
        [SerializeField] private float _remainingTime;

        public EventData(string EventId, float RemainingTime)
        {
            _eventId = EventId;
            _remainingTime = RemainingTime;
        }

        public float RemainingTime => _remainingTime;
        public string EventId => _eventId;
    }
}
