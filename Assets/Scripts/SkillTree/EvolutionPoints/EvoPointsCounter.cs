using UnityEngine;

namespace Sunflower.SkillTree.EvolutionPoints
{
    public static class EvoPointsCounter
    {
        private static EvoPointsCounterData _data;

        public static event System.Action<int> OnValueChanged;

        public static int Value
        {
            get => _data?.Value ?? 0;
            set
            {
                Debug.Log("Evo Points Changed: " + value);
                if (_data == null)
                    _data = new EvoPointsCounterData();

                _data.Value = value;

                OnValueChanged?.Invoke(value);
                Debug.Log("Event fired");
            }
        }

        public static void Initialize(EvoPointsCounterData data) => _data = data;
    }
}