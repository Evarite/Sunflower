using Sunflower.Modifiers;
using Sunflower.Needs;
using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Minerals Skill")]
    public class MineralsSkill : Skill
    {
        [SerializeField] private NeedSystem _needs;
        [SerializeField] private ModifierData _modifierData;
        private void Awake() => Id = SkillId.MineralsSkill;

        protected override void Ability() => _needs.ApplyModifier(_modifierData);
    }
}
