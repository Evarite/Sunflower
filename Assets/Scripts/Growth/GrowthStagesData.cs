using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Growth
{
    [CreateAssetMenu(fileName = "Growth Stages Data",
        menuName = "Sunflower/Growth/Growth Stages Data")]
    public class GrowthStagesData : ScriptableObject
    {
        [System.Serializable]
        public class GrowthStage
        {
            [SerializeField] private Sprite _sprite;
            [SerializeField] private float _maxHeight;

            public Sprite Sprite { get => _sprite; set => _sprite = value; }
            public float MaxHeight { get => _maxHeight; set => _maxHeight = value; }
        }

        [SerializeField] private List<GrowthStage> _growthStages = new();

        public IReadOnlyList<GrowthStage> GrowthStages { get => _growthStages; }
    }
}