using Sunflower.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SkillTree
{
    public class LoadNodes : MonoBehaviour
    {
        [SerializeField] private List<SkillPurchase> _nodes;

        private void Awake()
        {
            foreach (var node in _nodes)
                if (PlayerStateManager.Instance.OwnedSkills.Contains(node.SkillNode.Data.Id))
                    node.SwitchState();
        }
    }
}