using TMPro;
using UnityEngine;

namespace Sunflower.SkillTree.EvolutionPoints
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [AddComponentMenu("Sunflower/Skill Tree/Evolution Points/Evo Points UI")]
    public class EvoPointsUI : MonoBehaviour
    {
        TextMeshProUGUI _text;

        private void Awake() => _text = GetComponent<TextMeshProUGUI>();

        private void OnEnable() => EvoPointsCounter.OnValueChanged += OnValueChanged;

        private void OnDisable() => EvoPointsCounter.OnValueChanged -= OnValueChanged;

        private void OnValueChanged(int value) => _text.text = value.ToString();
    }
}