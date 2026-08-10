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

        [Tooltip("С каждым дополнительным пустым ресурсом время делится на это значение.")]
        [SerializeField] private float _additiveDivisor = 2f;

        private EmptyNeedsController _controller;

        private float _time;
        private Coroutine _timerCoroutine;

        public event System.Action OnTimerStarted;
        public event System.Action OnTimerEnded;
        public event System.Action<int> OnTimerUpdated;

        private void Awake()
        {
            _controller = GetComponent<EmptyNeedsController>();
        }

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
            while (_controller.EmptyNeeds.Count > 0)
            {
                _time -= Time.deltaTime;

                if (_time <= 0f)
                {
                    _time = 0f;
                    OnTimerUpdated?.Invoke(0);

                    LoseManager.Lose();
                    yield break;
                }

                OnTimerUpdated?.Invoke(Mathf.CeilToInt(_time));

                yield return null;
            }

            _timerCoroutine = null;
            OnTimerEnded?.Invoke();
        }

        private void EmptyAdded()
        {
            int emptyCount = _controller.EmptyNeeds.Count;

            _time = _loseTime /
                    Mathf.Pow(_additiveDivisor, emptyCount - 1);

            if (_timerCoroutine == null)
            {
                _timerCoroutine = StartCoroutine(Timer());
                OnTimerStarted?.Invoke();
            }

            OnTimerUpdated?.Invoke(Mathf.CeilToInt(_time));
        }

        private void EmptyRemoved()
        {
            int emptyCount = _controller.EmptyNeeds.Count;

            if (emptyCount <= 0)
            {
                if (_timerCoroutine != null)
                {
                    StopCoroutine(_timerCoroutine);
                    _timerCoroutine = null;
                }

                _time = 0f;

                OnTimerEnded?.Invoke();
                OnTimerUpdated?.Invoke(0);

                return;
            }

            _time = _loseTime /
                    Mathf.Pow(_additiveDivisor, emptyCount - 1);

            OnTimerUpdated?.Invoke(Mathf.CeilToInt(_time));
        }
    }
}