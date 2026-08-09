using Sunflower.Event;
using Sunflower.Needs;
using UnityEngine;

namespace Sunflower.Modules.Components
{
    [CreateAssetMenu(fileName = "New Component", menuName = "Sunflower/Modules Components/Production Component")]
    public class ProductionComponent : MonoBehaviour
    {
        [SerializeField] private Need _targetNeed;
        [SerializeField] private NeedId _productionStat;
        [SerializeField] private float _baseRate = 0.1f;

        [Tooltip("«ависит ли от HP (чем меньше HP, тем меньше производство)")]
        [SerializeField] private bool _dependsOnHealth = false;

        [SerializeField] private HealthComponent _health;

        private void Update()
        {
            //if (_targetNeed == null)
            //    return;

            //float rate = _baseRate;

            //if (GameEventSystem.Instance != null)
            //    rate = GameEventSystem.Instance.ApplyModifiers(_productionStat, rate);

            //if (_dependsOnHealth && _health != null)
            //    rate *= _health.HealthPercent;

            //_targetNeed.Value += rate * Time.deltaTime;
        }
    }
}
