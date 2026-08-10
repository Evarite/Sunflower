using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Base Skill")]
    public class BaseSkill : Skill
    {
        private void Awake() => Id = SkillId.BaseSkill;

        protected override void Ability()
        {

        }
    }
}