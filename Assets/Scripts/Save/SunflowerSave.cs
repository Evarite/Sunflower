using Sunflower.Growth;
using Sunflower.Needs;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [AddComponentMenu("Sunflower/Save/Sunflower Save")]
    public class SunflowerSave : MonoBehaviour
    {
        [SerializeField] private SunflowerGrowth _growth;
        [SerializeField] private List<Need> _needs = new();

        public SunflowerSaveData Save()
        {
            List<float> needsValues = new();
            foreach (var need in _needs)
                needsValues.Add(need.Value);

            return new SunflowerSaveData(_growth.Height, needsValues);
        }
    }
}