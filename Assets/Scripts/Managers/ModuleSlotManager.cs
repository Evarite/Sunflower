using System.Collections.Generic;
using Sunflower.Growth;
using UnityEngine;
using Sunflower.ModuleSlot;

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
            float currentHeight = _sunflowerGrowth.Height;
            int currentHundred = Mathf.FloorToInt(currentHeight / 100f);

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

        //Пытается установить модуль в указанный слот. Списание валюты происходит до вызова
        public bool TryInstallModule(ModuleData data, Slot targetSlot)
        {
            if (targetSlot.IsOccupied || targetSlot.InstalledModule != null)
                return false;
            if (targetSlot.SlotType != data.AllowedSlot)
                return false;

            GameObject modObj = Instantiate(data.Prefab, transform);
            Module module = modObj.GetComponent<Module>();
            module.Initialize(data, targetSlot);
            targetSlot.InstalledModule = module;
            return true;
        }
    }
}