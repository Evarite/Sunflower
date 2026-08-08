using UnityEngine;

namespace Sunflower.Needs.Timer
{
    [AddComponentMenu("Sunflower/Needs/Timer/Timer UI Toggle")]
    public class TimerUIToggle : MonoBehaviour
    {
        [SerializeField] private EmptyLoseTimer _timer;
        [SerializeField] private EmptyLoseTimerUI _timerUI;

        private void OnEnable()
        {
            _timer.OnTimerStarted += ActivateTimer;
            _timer.OnTimerEnded += DeactivateTimer;
        }

        private void OnDisable()
        {
            _timer.OnTimerStarted -= ActivateTimer;
            _timer.OnTimerEnded -= DeactivateTimer;
        }

        private void ActivateTimer() => _timerUI.gameObject.SetActive(true);

        private void DeactivateTimer() => _timerUI.gameObject.SetActive(false);
    }
}