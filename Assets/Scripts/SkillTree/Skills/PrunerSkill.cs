using Sunflower.ModuleSlot;
using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Pruner Skill")]
    public class PrunerSkill : Skill
    {
        public static PrunerSkill Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            Id = SkillId.PrunerSkill;
        }

        protected override void Ability()
        {

        }

        public void PruneSkill(Slot slot)
        {
            if (enabled)
                slot.RemoveModule();
        }
    }
}