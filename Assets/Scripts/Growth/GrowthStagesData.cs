using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Growth
{
    [CreateAssetMenu(fileName = "Growth Stages Data", menuName = "Sunflower/Growth Stages Data")]
    public class GrowthStagesData : ScriptableObject
    {
        [System.Serializable]
        public class GrowthStage
        {
            [SerializeField] private Sprite _sprite;
            [SerializeField] private float height;

            public Sprite Sprite { get => _sprite; set => _sprite = value; }
            public float Height { get => height; set => height = value; }
        }

        [SerializeField] private List<GrowthStage> _growthStages = new();

        public IReadOnlyList<GrowthStage> GrowthStages { get => _growthStages; }
    }
}