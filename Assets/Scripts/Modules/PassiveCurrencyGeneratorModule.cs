using Sunflower.Seeds;
using System.Reflection;
using UnityEngine;

namespace Sunflower.Modules
{
    [AddComponentMenu("Sunflower/Modules/Passive Currency Generator")]
    public class PassiveCurrencyGeneratorModule : Module
    {
        [SerializeField] private float _interval = 1f;
        [SerializeField] private int _amountPerTick = 1;

        private float _timer;

        public override float GetHeightMultiplier()
        {
            // Чем выше, тем больше семян (пример линейной зависимости)
            if (MySlot == null)
                return 1f; // fallback, если модуль не установлен через слот
            return 1f + MySlot.MinHeight * 0.001f;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _interval)
            {
                _timer -= _interval;
                int finalAmount = Mathf.RoundToInt(_amountPerTick * GetHeightMultiplier());
                SeedsCounter.Value += finalAmount;
            }
        }
    }
}