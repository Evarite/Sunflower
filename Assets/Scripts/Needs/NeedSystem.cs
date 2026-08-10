using System.Collections.Generic;
using Sunflower.Modifiers;
using UnityEngine;

namespace Sunflower.Needs
{
    [AddComponentMenu("Sunflower/Needs/Need System")]
    public class NeedSystem : MonoBehaviour
    {
        [SerializeField] private List<Need> needs;
        public IReadOnlyList<Need> Needs => needs;

        public Need Get(NeedData data)
        {
            if (data == null)
                return null;

            for (int i = 0; i < needs.Count; i++)
            {
                if (needs[i] != null && needs[i].NeedData == data)
                {
                    return needs[i];
                }
            }

            return null;
        }

        public void ApplyModifier(ModifierData modifier, UnityEngine.Object source = null)
        {
            if (modifier == null)
                return;

            // Если need == null, применяем ко всем потребностям.
            if (modifier.need == null)
            {
                for (int i = 0; i < needs.Count; i++)
                {
                    if (needs[i] != null)
                    {
                        needs[i].ApplyModifier(modifier, source);
                    }
                }

                return;
            }

            Need target = Get(modifier.need);

            if (target != null)
            {
                target.ApplyModifier(modifier, source);
            }
        }

        public void RemoveModifiersBySource(UnityEngine.Object source)
        {
            if (source == null)
                return;

            for (int i = 0; i < needs.Count; i++)
            {
                if (needs[i] != null)
                {
                    needs[i].RemoveModifiersBySource(source);
                }
            }
        }

    }
}