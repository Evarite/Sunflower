using Sunflower.Modifiers;
using Sunflower.Needs;
using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Water Skill")]
    public class WaterSkill : Skill
    {
        [SerializeField] private NeedSystem _needs;
        [SerializeField] private ModifierData _modifierData;

        private void Awake() => Id = SkillId.WaterSkill;

        protected override void Ability() => _needs.ApplyModifier(_modifierData);
    }
}
