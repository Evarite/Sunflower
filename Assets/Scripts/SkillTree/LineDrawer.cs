using UnityEngine;

namespace Sunflower.SkillTree
{
    [AddComponentMenu("Sunflower/Skill Tree/Line Drawer")]
    public class LineDrawer : MonoBehaviour
    {
        [SerializeField] private GameObject _lineRendererPrefab;

        public void DrawLine(Transform from, Transform to)
        {
            var renderer = Instantiate(_lineRendererPrefab);
            var _lineRenderer = renderer.GetComponent<LineRenderer>();

            _lineRenderer.SetPosition(0, from.position);
            _lineRenderer.SetPosition(1, to.position);
        }
    }
}