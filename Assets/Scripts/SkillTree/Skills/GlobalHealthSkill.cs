using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Global Health Skill")]
    public class GlobalHealthSkill : Skill
    {
        private void Awake() => Id = SkillId.GlobalHealthSkill;

        protected override void Ability()
        {

        }
    }
}
