namespace Sunflower.Seeds
{
    public static class SeedsCounter
    {
        private static SeedsCounterData _data;

        public static event System.Action<int> OnValueChanged;
        
        public static int Value
        {
            get => _data?.Value ?? 0;
            set
            {
                if (_data == null)
                    _data = new SeedsCounterData();

                _data.Value = value;

                OnValueChanged?.Invoke(value);
            }
        }

        public static void Initialize(SeedsCounterData data) => _data = data;
    }
}