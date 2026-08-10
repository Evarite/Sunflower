using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Minerals Skill")]
    public class MineralsSkill : Skill
    {
        private void Awake() => Id = SkillId.MineralsSkill;

        protected override void Ability()
        {

        }
    }
}
