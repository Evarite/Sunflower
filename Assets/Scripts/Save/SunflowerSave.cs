using Sunflower.Growth;
using Sunflower.Needs;
using Sunflower.SaveSystem.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [AddComponentMenu("Sunflower/Save/Sunflower Save")]
    public class SunflowerSave : MonoBehaviour
    {
        [SerializeField] private SunflowerGrowth _growth;
        [SerializeField] private List<Need> _needs = new();

        public SunflowerSaveData GetSaveData()
        {
            List<float> needsValues = new();

            foreach (var need in _needs)
                needsValues.Add(need.CurrentValue);

            return new SunflowerSaveData(
                _growth.Height,
                needsValues
            );
        }

        public void ApplySaveData(SunflowerSaveData data)
        {
            if (data == null)
                return;

            _growth.Height = data.Height;

            for (int i = 0; i < _needs.Count && i < data.NeedsValues.Count; i++)
            {
                _needs[i].CurrentValue = data.NeedsValues[i];
            }
        }
    }
}