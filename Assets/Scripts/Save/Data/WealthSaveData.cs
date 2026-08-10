using UnityEngine;

namespace Sunflower.SaveSystem.Data
{
    [System.Serializable]
    public class WealthSaveData
    {
        [SerializeField] private int _seeds;
        [SerializeField] private int _evoPoints;

        public WealthSaveData(int Seeds, int EvoPoints)
        {
            _seeds = Seeds;
            _evoPoints = EvoPoints;
        }

        public int Seeds => _seeds;
        public int EvoPoints => _evoPoints;
    }
}