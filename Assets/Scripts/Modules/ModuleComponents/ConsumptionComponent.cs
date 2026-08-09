using UnityEngine;
using Sunflower.Needs;
using Sunflower.Event;

namespace Sunflower.Modules.Components
{
    [CreateAssetMenu(fileName = "New Component", menuName = "Sunflower/Modules Components/Consumption Component")]
    public class ConsumptionComponent : MonoBehaviour
    {
        [SerializeField] private Need _targetNeed;
        [SerializeField] private NeedId _consumptionStat;
        [SerializeField] private float _baseRate = 0.05f;

        [SerializeField] private GameEventSystem eventSystem = null;

        private void Update()
        {
            //if (_targetNeed == null)
            //    return;

            //float rate = _baseRate;

            //if (eventSystem != null)
            //    rate = eventSystem.ApplyModifiers(_consumptionStat, rate);

            //_targetNeed.AddValue(rate * Time.deltaTime);
        }
    }
}