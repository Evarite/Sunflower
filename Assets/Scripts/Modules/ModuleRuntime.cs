using System.Reflection.Metadata.Ecma335;
using Sunflower.Modifiers;
using UnityEngine;

namespace Sunflower.Modules
{
    [RequireComponent(typeof(NeedComponent)), AddComponentMenu("Sunflower/Modules/Module Runtime")]
    public class ModuleRuntime : MonoBehaviour
    {
        [SerializeField] protected ModuleData _data;
        protected NeedComponent _needComponent;

        public ModuleData Data { get => _data; set => _data = value; }


        protected virtual void Awake()
        {
            if (_needComponent == null)
            {
                _needComponent = GetComponentInParent<NeedComponent>();
            }
        }

        private void Start()
        {
            ApplyActiveModifiers();
        }

        protected void ApplyActiveModifiers()
        {
            if (_data == null || _needComponent == null)
                return;

            if (_data.ActiveModifiers == null)
                return;

            foreach (ModifierData modifier in _data.ActiveModifiers)
            {
                if (modifier != null)
                {
                    _needComponent.ApplyModifier(modifier, this);
                }
            }
        }

        protected void RemoveModuleModifiers()
        {
            if (_needComponent != null)
            {
                _needComponent.RemoveModifiersBySource(this);
            }
        }

        protected virtual void OnDestroy()
        {
            RemoveModuleModifiers();
        }


    }

}