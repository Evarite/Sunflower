using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Utilities.WeightedRandom
{
    [System.Serializable]
    public class WeightedRandomList<T> : IReadOnlyList<T>
    {
        [System.Serializable]
        private class WeightedItem
        {
            [SerializeField] private T _value;
            [Min(0f)]
            [Tooltip("Probability, relative to other items in the collection")]
            [SerializeField] private float _probability;

            public T Value { get => _value; set => _value = value; }
            public float Probability { get => _probability; set => _probability = value; }

            public WeightedItem(T Value, float Probability)
            {
                _value = Value;
                _probability = Probability;
            }

        }

        [Header("Items")]
        [SerializeField] private List<WeightedItem> _collection = new();
        [Header("Empty")]
        [Tooltip("Relative probability of returning nothing")]
        [SerializeField] private float _emptyProbability = 10f;

        private float? _probabilityWeight = null;

        public int Count => _collection.Count;

        public float ProbabilityWeight
        {
            get
            {
                if (_probabilityWeight == null)
                    CalculateWeight();

                return (float)_probabilityWeight;
            }
        }

        public float EmptyProbability
        {
            get => _emptyProbability;
            set
            {
                if (_probabilityWeight == null)
                    CalculateWeight();

                _probabilityWeight -= _emptyProbability;
                _emptyProbability = value;
                _probabilityWeight += _emptyProbability;
            }
        }

        public void Add(T item, float probability)
        {
            var newItem = new WeightedItem(item, probability);

            _collection.Add(newItem);

            if (_probabilityWeight != null)
                _probabilityWeight += newItem.Probability;
            else
                CalculateWeight();
        }

        public void Remove(T item)
        {
            var itemToRemove = _collection.Find(x => EqualityComparer<T>.Default.Equals(x.Value, item));

            if (itemToRemove == null)
                return;

            if (_collection.Remove(itemToRemove))
            {
                if (_probabilityWeight != null)
                    _probabilityWeight -= itemToRemove.Probability;
                else
                    CalculateWeight();
            }
        }

        public T GetRandomItem()
        {
            if (_collection.Count == 0)
                return default;

            if (_probabilityWeight == null)
                CalculateWeight();

            float randomValue = Random.Range(0, (float)_probabilityWeight);

            float currentProbability = 0f;
            foreach (var item in _collection)
            {
                currentProbability += item.Probability;

                if (randomValue < currentProbability)
                    return item.Value;
            }

            return default; //Can return null, that means that nothing dropped.
        }

        public void ChangeProbability(T item, float newProbability)
        {
            var itemToChange = _collection.Find(x => EqualityComparer<T>.Default.Equals(x.Value, item));
            if (itemToChange != null)
            {
                UpdateItemProbability(itemToChange, newProbability);
            }
        }

        public void ChangeProbability(int index, float newProbability)
        {
            if (index >= 0 && index < _collection.Count)
            {
                var item = _collection[index];

                UpdateItemProbability(item, newProbability);
            }
        }

        public void Clear()
        {
            _collection.Clear();
            _probabilityWeight = null;
        }

        public T this[int index] => _collection[index].Value;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _collection)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void UpdateItemProbability(WeightedItem item, float newProbability)
        {
            if (_probabilityWeight == null)
                CalculateWeight();

            _probabilityWeight -= item.Probability;
            item.Probability = newProbability;
            _probabilityWeight += item.Probability;
        }

        private void CalculateWeight()
        {
            _probabilityWeight = 0f;

            foreach (var item in _collection)
                _probabilityWeight += item.Probability;

            _probabilityWeight += _emptyProbability;
        }
    }
}