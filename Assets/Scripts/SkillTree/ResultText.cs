using Sunflower.Managers;
using TMPro;
using UnityEngine;

namespace Sunflower.SkillTree
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ResultText : MonoBehaviour
    {
        [SerializeField] private float _activeTime = 3f;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = $"+{PlayerStateManager.Instance.PointsEarned.ToString()}";
            Destroy(gameObject, _activeTime);
        }
    }
}