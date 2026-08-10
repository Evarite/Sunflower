using Sunflower.Modifiers;
using Sunflower.Needs;
using UnityEngine;

namespace Sunflower.Modules
{
    [RequireComponent(typeof(NeedComponent))]
    [AddComponentMenu("Sunflower/Modules/Module Runtime")]
    public class ModuleRuntime : MonoBehaviour
    {
        [SerializeField] protected ModuleData _data;

        public ModuleData Data
        {
            get => _data;
            set => _data = value;
        }

        protected virtual void Start()
        {
            ApplyActiveModifiers();
        }

        protected void ApplyActiveModifiers()
        {
            if (_data == null || NeedSystem.Instance == null)
                return;

            if (_data.ActiveModifiers == null)
                return;

            foreach (ModifierData modifier in _data.ActiveModifiers)
            {
                if (modifier != null)
                    NeedSystem.Instance.ApplyModifier(modifier, this);
            }
        }

        protected void RemoveModuleModifiers()
        {
            if (NeedSystem.Instance != null)
                NeedSystem.Instance.RemoveModifiersBySource(this);
        }

        protected virtual void OnDestroy()
        {
            RemoveModuleModifiers();
        }
    }
}