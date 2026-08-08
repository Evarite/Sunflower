using TMPro;
using UnityEngine;

namespace Sunflower.SkillTree
{
    [AddComponentMenu("Sunflower/Skill Tree/Skill Node")]
    public class SkillNode : MonoBehaviour
    {
        [SerializeField] private SkillNodeData _data;

        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _cost;

        private void Awake()
        {
            _name.text = _data.Name;
            _description.text = _data.Description;
            _cost.text = _data.Cost.ToString();
        }
    }
}