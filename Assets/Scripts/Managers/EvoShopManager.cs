using Sunflower.SkillTree;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Managers
{
    public class EvoShopManager : MonoBehaviour
    {
        [Tooltip("Список купленных и доступных к покупке узлов.")]
        [SerializeField] private List<SkillNode> _unlockedNodes;
    }
}
