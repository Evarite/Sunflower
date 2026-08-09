using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Attack Health Skill")]
    public class AttackHealthSkill : Skill
    {
        private void Awake() => Id = SkillId.AttackHealthSkill;

        protected override void Ability()
        {

        }
    }
}
