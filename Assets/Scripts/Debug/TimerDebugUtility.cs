#if UNITY_EDITOR
using Sunflower.Needs;
using System.Collections;
using UnityEngine;

namespace Sunflower.Debugging
{
    public class TimerDebugUtility : MonoBehaviour
    {
        [SerializeField] private float _offset = 0f;
        [SerializeField] private float _step = 0.05f;
        [SerializeField] private Need _need;

        private void Awake() => StartCoroutine(DecreaseNeed());

        private IEnumerator DecreaseNeed()
        {
            yield return new WaitForSeconds(_offset);

            while (true)
            {
                _need.CurrentValue -= _step;
                yield return null;
            }
        }
    }
}
#endif