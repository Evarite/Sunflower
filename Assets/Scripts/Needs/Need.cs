using Sunflower.Modifiers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Needs
{
    public class Need : MonoBehaviour
    {
        [SerializeField] private NeedData needData;

        [Tooltip("Íà÷àëüíîå çíà÷åíèå â ïðîöåíòàõ îò ìàêñèìàëüíîãî")]
        [SerializeField, Range(0f, 1f)] private float startNormalized = 0.5f;

        private List<ActiveModifier> _modifiers;
        private float _currentValue;
        private float _maxValue;

        public event Action<float> OnMaxValueChanged;
        public event Action<Need, float> OnValueChanged;
        public event Action<Need> OnNeedEmpty;

        public NeedData NeedData => needData;

        public float CurrentValue
        {
            get => _currentValue;
            set
            {
                float clamped = Mathf.Clamp(value, 0f, MaxValue);

                if (Mathf.Approximately(clamped, _currentValue))
                    return;

                bool wasEmpty = Mathf.Approximately(_currentValue, 0f);

                _currentValue = clamped;

                OnValueChanged?.Invoke(this, _currentValue);

                if (!wasEmpty && Mathf.Approximately(_currentValue, 0f))
                    OnNeedEmpty?.Invoke(this);
            }
        }

        public float MaxValue
        {
            get => _maxValue;
            set
            {
                if (value < 0f || Mathf.Approximately(_maxValue, value))
                    return;

                _maxValue = value;

                OnMaxValueChanged?.Invoke(_maxValue);

                CurrentValue = _currentValue;
            }
        }

        public float BaseFillRate => needData != null ? needData.baseFillRate : 0f;
        public float BaseCapacity => needData != null ? needData.baseCapacity : 0f;

        public float FillRate { get; private set; }

        private void Awake()
        {
            _modifiers = new List<ActiveModifier>();

            _maxValue = needData.baseCapacity;
            CurrentValue = _maxValue * startNormalized;

            RecalculateStats();
        }

        private void Start()
        {
            OnMaxValueChanged?.Invoke(_maxValue);
            OnValueChanged?.Invoke(this, _currentValue);
        }

        private void Update()
        {
            if (needData == null)
                return;

            if (UpdateModifierDurations(Time.deltaTime))
                RecalculateStats();

            // An empty need stays empty until it is explicitly restored.
            if (!Mathf.Approximately(CurrentValue, 0f))
                AddValue(FillRate * Time.deltaTime);
        }

        public void AddValue(float amount)
        {
            
            float newValue = Mathf.Clamp(CurrentValue + amount, 0f, MaxValue);

            if (Mathf.Approximately(newValue, CurrentValue))
                return;

            CurrentValue = newValue;
        }

        public void AddCapacity(float amount)
        {
            MaxValue += amount;
        }

        public void ApplyModifier(ModifierData modifier)
        {
            if (modifier == null)
                return;

            ApplyModifier(modifier, modifier.source);
        }

        public void ApplyModifier(
            ModifierData modifier,
            UnityEngine.Object source)
        {
            if (modifier == null || !IsTargetNeed(modifier.need))
                return;

            switch (modifier.type)
            {
                case ModifierType.AddValue:
                    AddValue(modifier.value);
                    break;

                case ModifierType.AddCapacity:
                case ModifierType.MultiplyCapacity:
                case ModifierType.AddFillRate:
                case ModifierType.MultiplyFillRate:
                    AddModifier(modifier, source);
                    RecalculateStats();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(modifier),
                        $"Unknown modifier type: {modifier.type}"
                    );
            }
        }

        public void RemoveModifiersBySource(UnityEngine.Object source)
        {
            if (source == null)
                return;

            int removed = _modifiers.RemoveAll(m => m.source == source);

            if (removed <= 0)
                return;

            RecalculateStats();
        }

        public void ClearModifiers()
        {
            if (_modifiers.Count == 0)
                return;

            _modifiers.Clear();
            RecalculateStats();
        }

        private bool IsTargetNeed(NeedData target)
        {
            return target == null || target == needData;
        }

        private void AddModifier(
            ModifierData modifier,
            UnityEngine.Object source)
        {
            if (source != null)
            {
                _modifiers.RemoveAll(
                    m => m.source == source && m.type == modifier.type
                );
            }

            _modifiers.Add(new ActiveModifier
            {
                type = modifier.type,
                value = modifier.value,
                duration = modifier.duration,
                source = source
            });
        }

        private bool UpdateModifierDurations(float deltaTime)
        {
            bool changed = false;

            for (int i = _modifiers.Count - 1; i >= 0; i--)
            {
                ActiveModifier modifier = _modifiers[i];

                if (!ReferenceEquals(modifier.source, null) &&
                    modifier.source == null)
                {
                    _modifiers.RemoveAt(i);
                    changed = true;
                    continue;
                }

                // <= 0 means infinite duration.
                if (modifier.duration <= 0f)
                    continue;

                modifier.duration -= deltaTime;

                if (modifier.duration <= 0f)
                {
                    _modifiers.RemoveAt(i);
                    changed = true;
                }
            }

            return changed;
        }

        private void RecalculateStats()
        {
            float additive = 0f;
            float multiplicative = 1f;
            float addCapacity = 0f;
            float multCapacity = 1f;

            foreach (ActiveModifier modifier in _modifiers)
            {
                switch (modifier.type)
                {
                    case ModifierType.AddCapacity:
                        addCapacity += modifier.value;
                        break;
                    case ModifierType.MultiplyCapacity:
                        multCapacity *= modifier.value;
                        break;

                    case ModifierType.AddFillRate:
                        additive += modifier.value;
                        break;

                    case ModifierType.MultiplyFillRate:
                        multiplicative *= modifier.value;
                        break;
                }
            }

            FillRate = (BaseFillRate + additive) * multiplicative;
            Debug.Log(multCapacity);
            MaxValue = (BaseCapacity + addCapacity)*multCapacity;
        }
    }
}