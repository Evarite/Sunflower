#if UNITY_EDITOR
using Sunflower.SkillTree.EvolutionPoints;
using UnityEngine;

namespace Sunflower.Debugging
{
    public class EvoPointsSetUp : MonoBehaviour
    {
        [SerializeField] private int _value;

        private void Start() => EvoPointsCounter.Value = _value;
    }
}
#endif