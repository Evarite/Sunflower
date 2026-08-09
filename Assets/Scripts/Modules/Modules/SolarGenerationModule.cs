using Sunflower.Needs;
using Sunflower.Event;
using UnityEngine;

namespace Sunflower.Modules
{
    public class SolarGenerationModule : Module
    {


        [SerializeField]
        [Range(0,1)]
        private float _baseProductionRate = 0.3f;

        [Header("Water Storage Bonus")]
        [SerializeField] private Need _waterNeed;
        [SerializeField] private float _waterStorageBonus = 0.2f;

        [SerializeField]
        GameEventSystem _gameEventSystem = null;


        private float _originalWaterMax;
        private bool _hasBonus;

        protected override void Awake()
        {
            base.Awake();

            if (_waterNeed != null)
            {
                _originalWaterMax = _waterNeed.MaxValue;
                _waterNeed.MaxValue += _waterStorageBonus;
                _hasBonus = true;
            }
        }

        private void Update()
        {
            //if (_sunNeedConsumption == null)
            //    return;

            //// производство зависит от HP
            //float healthPercent = CurrentHealth / Data.MaxHealth;
            //float productionRate = _baseProductionRate * healthPercent;

            //if (_gameEventSystem != null)
            //    productionRate = _gameEventSystem.ApplyModifiers(NeedId.Sun, productionRate);

            

            //_sunNeedConsumption.Value += productionRate;
        }

        protected override void Die()
        {
            if (_hasBonus && _waterNeed != null)
            {
                _waterNeed.MaxValue = _originalWaterMax;
            }

            base.Die();
        }
    }
}