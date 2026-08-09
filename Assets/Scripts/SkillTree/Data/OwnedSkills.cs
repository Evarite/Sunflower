using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SkillTree.Data
{
    [System.Serializable]
    public class OwnedSkills
    {
        [SerializeField] private List<SkillId> _purchasedSkills = new();

        public List<SkillId> PurchasedSkills { get => _purchasedSkills; }
    }
}