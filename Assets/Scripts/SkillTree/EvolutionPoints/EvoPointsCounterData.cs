using UnityEngine;

namespace Sunflower.SkillTree.EvolutionPoints
{
    [System.Serializable]
    public class EvoPointsCounterData
    {
        [SerializeField] private int _value = 0;

        public int Value
        {
            get => _value;
            set => _value = value;
        }
    }
}