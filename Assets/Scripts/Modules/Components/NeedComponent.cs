using System;
using Sunflower.Modifiers;
using Sunflower.Needs;
using UnityEngine;

namespace Sunflower.Modules
{
    [AddComponentMenu("Sunflower/Module Components/Needs")]
    public class NeedComponent : MonoBehaviour
    {

        [SerializeField] private NeedSystem _needSystem;

        public void ApplyModifier(ModifierData modifier, ModuleRuntime moduleRuntime)
        {

            if (_needSystem == null)
                return;

            _needSystem.ApplyModifier(modifier, moduleRuntime);
        }

        public void RemoveModifiersBySource(ModuleRuntime moduleRuntime)
        {
            if (_needSystem == null)
                return;

            _needSystem.RemoveModifiersBySource(moduleRuntime);
        }
    }
}