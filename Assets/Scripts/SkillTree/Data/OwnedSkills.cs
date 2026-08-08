using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SkillTree.Data
{
    [System.Serializable]
    public class OwnedSkills
    {
        [SerializeField] private List<SkillId> _skills = new();

        public List<SkillId> Skills { get => _skills; }
    }
}