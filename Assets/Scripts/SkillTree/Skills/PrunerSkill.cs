using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Pruner Skill")]
    public class PrunerSkill : Skill
    {
        private void Awake() => Id = SkillId.PrunerSkill;

        protected override void Ability()
        {

        }
    }
}
