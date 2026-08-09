using UnityEngine;

namespace Sunflower.SaveSystem.Data
{
    [System.Serializable]
    public class GameSaveData
    {
        [SerializeField] private SunflowerSaveData _sunflowerSaveData;
        [SerializeField] private WealthSaveData _wealthSaveData;
    }
}
