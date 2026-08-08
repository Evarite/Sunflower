using Sunflower.Event;
using UnityEngine;

namespace Sunflower.Needs
{
    [AddComponentMenu("Sunflower/Needs/Need Consumption")]
    public class NeedConsumption : MonoBehaviour
    {

        [SerializeField]
        [Range(0,1)]
        private float _needVelocity = 0.20f;

        [SerializeField]
        private GameEventSystem _gameEventSystem = null;

        [SerializeField]
        private Need _need = null;

        private void Update()
        {
            if (_need == null)
                return;

            float finalVelocity = _gameEventSystem.ApplyModifiers(_need.Id, _needVelocity);

            _need.Value += finalVelocity * Time.deltaTime;
        }

    }
}