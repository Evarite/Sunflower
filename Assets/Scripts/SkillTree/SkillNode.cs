using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.SkillTree
{
    [ExecuteAlways]
    [AddComponentMenu("Sunflower/Skill Tree/Skill Node")]
    public class SkillNode : MonoBehaviour
    {
        [SerializeField] private SkillNodeData _data;

        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _cost;
        [SerializeField] private Image _skillPicture;

        public SkillNodeData Data { get => _data; set => _data = value; }

        private void Awake() => Refresh();

        private void OnValidate() => Refresh();

        private void Reset() => Refresh();

        private void Refresh()
        {
            _name.text = _data.Name;
            _description.text = _data.Description;
            _cost.text = _data.Cost.ToString();
            _skillPicture.sprite = _data.SkillPicture;
        }
    }
}