using UnityEngine;
using UnityEngine.EventSystems;

namespace Sunflower.SkillTree
{
    [AddComponentMenu("Sunflower/Skill Tree/Skill Node Pointer")]
    [RequireComponent(typeof(BoxCollider2D))]
    public class SkillNodePointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject _description;

        [SerializeField] private Vector2 _idleColliderSize;
        [SerializeField] private Vector2 _activeColliderSize;

        [SerializeField] private GameObject _detectionZone;

        private void Awake() => _description.SetActive(false);

        public void OnPointerEnter(PointerEventData eventData)
        {
            _description.SetActive(true);

            _detectionZone.transform.localScale = _activeColliderSize;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _description.SetActive(false);

            _detectionZone.transform.localScale = _idleColliderSize;
        }
    }
}