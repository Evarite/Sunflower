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

    public event System.Action<int> OnValueChanged;
}