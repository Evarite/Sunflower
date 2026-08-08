using Sunflower.Needs;
using UnityEngine;
using Sunflower.Event;


#if UNITY_EDITOR
using Sunflower.Needs;
using System.Collections;
using UnityEngine;

namespace Sunflower.Debugging
{
    public class EventDebugUtility : MonoBehaviour
    {
        [SerializeField]
        private GameEventDefinition gameEventDefinition = null;

        [SerializeField]
        private GameEventSystem _gameEventSystem = null;
        private void Start()
        {
            _gameEventSystem.StartEvent(gameEventDefinition);
        }
    }
}
#endif