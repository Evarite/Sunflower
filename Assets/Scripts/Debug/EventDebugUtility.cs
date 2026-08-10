

#if UNITY_EDITOR
using System.Collections;
using UnityEngine;
using Sunflower.Event;


namespace Sunflower.Debugging
{
    public class EventDebugUtility : MonoBehaviour
    {
        [SerializeField]
        private GameEventData gameEventDefinition = null;

        [SerializeField]
        private GameEventSystem _gameEventSystem = null;
        private void Start()
        {
            _gameEventSystem.StartEvent(gameEventDefinition);
        }
    }
}
#endif