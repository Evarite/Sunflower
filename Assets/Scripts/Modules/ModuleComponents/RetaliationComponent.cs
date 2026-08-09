using Sunflower.Modules.Components;
using UnityEngine;
namespace Sunflower.Modules.Components
{
    [CreateAssetMenu(fileName = "New Component", menuName = "Sunflower/Modules Components/Retaliation Component")]
    public class RetaliationComponent : MonoBehaviour
    {
        [SerializeField] private HealthComponent _health;
        [SerializeField] private float _damage = 5f;
        [SerializeField] private int _maxCharges = 6;

        private int _currentCharges;

        private void Awake()
        {
            _currentCharges = _maxCharges;

            if (_health != null)
                _health.OnDamaged += OnDamaged;
        }

        private void OnDestroy()
        {
            if (_health != null)
                _health.OnDamaged -= OnDamaged;
        }

        private void OnDamaged(float damage)
        {
            if (_currentCharges <= 0)
                return;

            _currentCharges--;

            // найти атакующего врага и нанести урон
            // можно кэшировать последнего атакующего в HealthComponent
            // или искать ближайшего врага в радиусе
        }
    }
}