using Sunflower.Modifiers;
using Sunflower.Needs;
using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Base Skill")]
    public class BaseSkill : Skill
    {
        [SerializeField] private NeedSystem _needs;
        [SerializeField] private ModifierData _modifierData;

        private void Awake() => Id = SkillId.BaseSkill;

        protected override void Ability() => _needs.ApplyModifier(_modifierData);
    }
}