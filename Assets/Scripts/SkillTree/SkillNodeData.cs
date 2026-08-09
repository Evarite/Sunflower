using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.SkillTree
{
    [System.Serializable]
    public class SkillNodeData
    {
        [SerializeField] private SkillId _id;
        [SerializeField] private Sprite _skillPicture;
        [SerializeField] private string _name = "Новый навык";
        [SerializeField] private string _description = "Хороший навык";
        [SerializeField] private int _cost = 0;

        public string Name { get => _name; }
        public string Description { get => _description; }
        public int Cost { get => _cost; }
        public SkillId Id { get => _id; }
        public Sprite SkillPicture { get => _skillPicture; }
    }
}