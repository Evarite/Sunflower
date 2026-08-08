#if UNITY_EDITOR
using Sunflower.SkillTree.EvolutionPoints;
using UnityEngine;

namespace Sunflower.Debugging
{
    public class EvoPointsIncrease : MonoBehaviour
    {
        [SerializeField] private int _value = 10;

        private void Update() => EvoPointsCounter.Value += _value;
    }
}
#endif