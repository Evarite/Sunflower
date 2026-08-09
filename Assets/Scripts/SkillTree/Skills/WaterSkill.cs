using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Water Skill")]
    public class WaterSkill : Skill
    {
        private void Awake() => Id = SkillId.WaterSkill;

        protected override void Ability()
        {

        }
    }
}
