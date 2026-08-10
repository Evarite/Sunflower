using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Light Skill")]
    public class LightSkill : Skill
    {
        private void Awake() => Id = SkillId.LightSkill;

        protected override void Ability()
        {

        }
    }
}
