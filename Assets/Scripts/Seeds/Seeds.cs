namespace Sunflower.Seeds
{
    [System.Serializable]
    public class SeedsCounter
    {
        private int _value = 0;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        public static event System.Action<int> OnValueChanged;
    }
}