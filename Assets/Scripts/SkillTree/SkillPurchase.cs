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
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _purchaseSuccessfull;
        [SerializeField] private AudioClip _purchaseDenied;

        private int _cost;

        private void Start() => _cost = int.Parse(_costText.text);

        private void OnEnable() => _purchaseButton.onClick.AddListener(ButtonPressed);

        private void OnDisable() => _purchaseButton.onClick.RemoveAllListeners();

        private void ButtonPressed()
        {
            Debug.Log($"{EvoPointsCounter.Value}\t{_cost}");

            if (EvoPointsCounter.Value >= _cost)
            {
                _audioSource.PlayOneShot(_purchaseSuccessfull);
            }
            else
                _audioSource.PlayOneShot(_purchaseDenied);
        }
    }
}