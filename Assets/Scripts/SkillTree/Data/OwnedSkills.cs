using System.Collections.Generic;

namespace Sunflower.SkillTree.Data
{
    [System.Serializable]
    public class OwnedSkills
    {
        private List<SkillNodeData> _skills = new();

        public List<SkillNodeData> Skills { get => _skills; set => _skills = value; }
    }
}