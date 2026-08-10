using System;
using System.Collections.Generic;
using Sunflower.Modifiers;
using Sunflower.Needs;
using UnityEngine;

namespace Sunflower.Modules
{
    [AddComponentMenu("Sunflower/Module Components/Needs")]
    public class NeedComponent : MonoBehaviour
    {
        public void ApplyModifier(ModifierData modifier, ModuleRuntime moduleRuntime)
        {

            if (NeedSystem.Instance == null)
                return;

            NeedSystem.Instance.ApplyModifier(modifier, moduleRuntime);
        }

        public void ApplyModifiers(List<ModifierData> modifiers, UnityEngine.Object source)
        {

            if (_needSystem == null)
                return;

            foreach (ModifierData modifier in modifiers)
            {
                _needSystem.ApplyModifier(modifier, source);
            }
        }


        public void ApplyModifiers(List<ModifierData> modifiers, UnityEngine.Object source)
        {

            if (_needSystem == null)
                return;

            foreach (ModifierData modifier in modifiers)
            {
                _needSystem.ApplyModifier(modifier, source);
            }
        }


        public void RemoveModifiersBySource(ModuleRuntime moduleRuntime)
        {
            if (NeedSystem.Instance == null)
                return;

            NeedSystem.Instance.RemoveModifiersBySource(moduleRuntime);
        }
    }
}