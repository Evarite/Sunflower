using Sunflower.Growth;
using Sunflower.ModuleSlot;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Modules
{
    [RequireComponent(typeof(SunflowerGrowth))]
    [AddComponentMenu("Sunflower/Modules/Slot Manager")]
    public class SlotManager : MonoBehaviour
    {
        [SerializeField] private int _minStemSlotsPer100m = 1;
        [SerializeField] private int _maxStemSlotsPer100m = 3;
        [SerializeField, Range(0f, 1f)] private float _envSlotChance = 0.2f;

        [SerializeField] private List<Slot> _allSlots = new();

        private SunflowerGrowth _sunflowerGrowth;
        private int _lastProcessedHundred;

        public IReadOnlyList<Slot> AllSlots => _allSlots;

        private void Awake() => _sunflowerGrowth = GetComponent<SunflowerGrowth>();

        private void Update()
        {
            int currentHeight = (int)_sunflowerGrowth.Height;
            int currentHundred = currentHeight / 100;

            if (currentHundred > _lastProcessedHundred)
            {
                for (int h = _lastProcessedHundred + 1; h <= currentHundred; h++)
                {
                    float baseHeight = h * 100f;
                    int stemCount = Random.Range(_minStemSlotsPer100m, _maxStemSlotsPer100m + 1);
                    for (int i = 0; i < stemCount; i++)
                        _allSlots.Add(new Slot(SlotType.Stem, baseHeight, baseHeight + 100f));

                    if (Random.value < _envSlotChance)
                        _allSlots.Add(new Slot(SlotType.Environment, baseHeight, baseHeight + 100f));
                }
                _lastProcessedHundred = currentHundred;
            }

            // Фиксация пройденных по высоте слотов
            foreach (var slot in _allSlots)
            {
                if (!slot.IsOccupied && currentHeight >= slot.MaxHeight)
                    slot.IsOccupied = true;
            }
        }
    }
}