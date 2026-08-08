using UnityEngine;

namespace Sunflower.Seeds
{
    [System.Serializable]
    public class SeedsCounterData
    {
        [SerializeField] private int _value = 0;

        public int Value
        {
            get => _value;
            set => _value = value;
        }
    }
}