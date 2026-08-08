using Sunflower.Managers;
using Sunflower.SkillTree.EvolutionPoints;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.SkillTree
{
    [AddComponentMenu("Sunflower/Skill Tree/Skill Purchase")]
    public class SkillPurchase : MonoBehaviour
    {
        [Header("Button")]
        [SerializeField] private Button _purchaseButton;

        [Header("Cost")]
        [SerializeField] private TextMeshProUGUI _costText;

        [Header("Audio")]
        [SerializeField] private AudioClip _purchaseSuccessfull;
        [SerializeField] private AudioClip _purchaseDenied;

        private int _cost;

        private void Start() => _cost = int.Parse(_costText.text);

        private void OnEnable() => _purchaseButton.onClick.AddListener(ButtonPressed);

        private void OnDisable() => _purchaseButton.onClick.RemoveAllListeners();

        private void ButtonPressed()
        {
            if (EvoPointsCounter.Value >= _cost)
            {
                AudioManager.Instance.PlaySound(_purchaseSuccessfull);

                EvoPointsCounter.Value -= _cost;
            }
            else
                AudioManager.Instance.PlaySound(_purchaseDenied);
        }
    }
}