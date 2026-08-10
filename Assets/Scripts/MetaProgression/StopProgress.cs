using Sunflower.Growth;
using Sunflower.Managers;
using System.Collections;
using UnityEngine;

namespace Sunflower.MetaProgression
{
    public class StopProgress : MonoBehaviour
    {
        [SerializeField] private Barriers _barriers;
        [SerializeField] private SunflowerGrowth _growth;
        [SerializeField] private GameObject _stopInfoScreen;

        private IEnumerator Barrier()
        {
            yield return new WaitUntil(() =>
            _growth.Height <= _barriers.MaxHeights[PlayerStateManager.Instance.CurrentRun]);

            _growth.Modifiers.Add(0);

            PlayerStateManager.Instance.CanIncreaseRun = true;
        }
    }
}