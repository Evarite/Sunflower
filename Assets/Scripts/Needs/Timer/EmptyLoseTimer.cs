using Sunflower.Managers;
using System.Collections;
using UnityEngine;

namespace Sunflower.Needs.Timer
{
    [RequireComponent(typeof(EmptyNeedsController))]
    [AddComponentMenu("Sunflower/Needs/Timer/Empty Lose Timer")]
    public class EmptyLoseTimer : MonoBehaviour
    {
        [Header("Lose Time")]
        [SerializeField] private float _loseTime = 24f;
        [Tooltip("С каждым дополнительным пустым ресурсом оставшееся время делится на это значение.")]
        [SerializeField] private float _additiveDivisor = 2f;

        private EmptyNeedsController _controller;

        private float _time;
        private Coroutine _timerCoroutine;

        public event System.Action OnTimerStarted;
        public event System.Action OnTimerEnded;
        public event System.Action<int> OnTimerUpdated;

        private void Awake() => _controller = GetComponent<EmptyNeedsController>();

        private void OnEnable()
        {
            _controller.OnEmptyAdded += EmptyAdded;
            _controller.OnEmptyRemoved += EmptyRemoved;
        }

        private void OnDisable()
        {
            _controller.OnEmptyAdded -= EmptyAdded;
            _controller.OnEmptyRemoved -= EmptyRemoved;
        }

        private IEnumerator Timer()
        {
            _time = _loseTime;
            int displayedTime = (int)_time;

            OnTimerUpdated?.Invoke(displayedTime);

            //Ждём секунду, чтобы значение не изменилось мгновенно
            yield return new WaitForSeconds(1f);

            while (_time > 0f)
            {
                _time -= Time.deltaTime;

                if (_time <= 0f)
                    break;

                if (_time <= displayedTime)
                {
                    displayedTime = (int)_time;
                    OnTimerUpdated?.Invoke(displayedTime);
                }
                else
                    displayedTime = (int)_time;

                yield return null;
            }

            LoseManager.Lose();
        }

        private void EmptyAdded()
        {
            //Если 1, то просто запустить таймер
            if (_controller.EmptyNeeds.Count > 1)
                _time /= _additiveDivisor;
            else
            {
                _timerCoroutine = StartCoroutine(Timer());
                OnTimerStarted?.Invoke();
            }
        }

        private void EmptyRemoved()
        {
            if (_controller.EmptyNeeds.Count > 0)
                _time *= _additiveDivisor;
            else if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
                OnTimerEnded?.Invoke();
            }
        }
    }
}