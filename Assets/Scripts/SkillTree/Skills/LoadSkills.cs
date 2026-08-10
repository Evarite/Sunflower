using Sunflower.Managers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    [AddComponentMenu("Sunflower/Skills/Load Skills")]
    public class LoadSkills : MonoBehaviour
    {
        private List<Skill> _skills;

        private void Awake() => _skills = GetComponents<Skill>().ToList();

        private void Start()
        {
            foreach (var skill in _skills)
            {
                if (PlayerStateManager.Instance.OwnedSkills.Contains(skill.Id))
                    skill.enabled = true;
                else
                    skill.enabled = false;
            }
        }
    }
}