using Sunflower.Modules;
using Sunflower.ModuleSlot;
using UnityEngine;

public abstract class Module : MonoBehaviour
{
    public ModuleData Data { get; private set; }
    public Slot MySlot { get; private set; }
    public float CurrentHealth { get; protected set; }

    public void Initialize(ModuleData data, Slot slot)
    {
        Data = data;
        MySlot = slot;
        CurrentHealth = data.MaxHealth;
        OnPlaced();
    }

    protected virtual void OnPlaced() { }

    public virtual void TakeDamage(float damage)
    {
        if (MySlot.SlotType != SlotType.Stem)
            return;

        CurrentHealth -= damage;
        if (CurrentHealth <= 0f)
            Die();
    }

    protected virtual void Die()
    {
        MySlot.InstalledModule = null;
        Destroy(gameObject);
    }

    /// <summary> Переопределяется в наследниках для учёта высоты. </summary>
    public virtual float GetHeightMultiplier() => 1f;

}