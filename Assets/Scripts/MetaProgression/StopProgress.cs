using Sunflower.Growth;
using Sunflower.Loading;
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

        private void Awake()
        {
            StartCoroutine(Barrier());
            _stopInfoScreen.SetActive(false);
        }

        private IEnumerator Barrier()
        {
            yield return new WaitUntil(() =>
            _growth.Height >= _barriers.MaxHeights[PlayerStateManager.Instance.CurrentRun]);

            _growth.Modifiers.Add(0);

            if (PlayerStateManager.Instance.CurrentRun == _barriers.MaxHeights.Count - 1)
                LoadingScreen.LoadScene("WinScene");
            else
            {
                PlayerStateManager.Instance.CanIncreaseRun = true;
                _stopInfoScreen.SetActive(true);
            }
        }
    }
}