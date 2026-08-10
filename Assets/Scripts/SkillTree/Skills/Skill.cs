using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree.Skills
{
    public abstract class Skill : MonoBehaviour
    {
        private SkillId _id;

        public SkillId Id { get => _id; protected set => _id = value; }

        private void Start() => Ability();

        protected abstract void Ability();
    }
}