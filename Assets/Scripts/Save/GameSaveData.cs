using UnityEngine;

namespace Sunflower.SaveSystem.Data
{
    [System.Serializable]
    public class GameSaveData
    {
        [SerializeField] private SunflowerSaveData _sunflowerSaveData;
        [SerializeField] private WealthSaveData _wealthSaveData;
        [SerializeField] private EventsSaveData _eventsSaveData;

        public GameSaveData(SunflowerSaveData SunflowerSaveData, WealthSaveData WealthSaveData,
            EventsSaveData EventsSaveData)
        {
            _sunflowerSaveData = SunflowerSaveData;
            _wealthSaveData = WealthSaveData;
            _eventsSaveData = EventsSaveData;
        }

        public SunflowerSaveData SunflowerSaveData => _sunflowerSaveData;
        public WealthSaveData WealthSaveData => _wealthSaveData;
        public EventsSaveData EventsSaveData => _eventsSaveData;
    }
}