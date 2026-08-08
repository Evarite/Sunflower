using TMPro;
using UnityEngine;

namespace Sunflower.Needs.Timer
{
    [AddComponentMenu("Sunflower/Needs/Timer/Empty Needs Timer UI")]
    public class EmptyLoseTimerUI : MonoBehaviour
    {
        [SerializeField] private EmptyLoseTimer _timer;
        [SerializeField] private TextMeshProUGUI _timerText;

        private void OnEnable() => _timer.OnTimerUpdated += OnValueUpdated;

        private void OnDisable() => _timer.OnTimerUpdated -= OnValueUpdated;

        private void OnValueUpdated(int time) => _timerText.text = time.ToString();
    }
}