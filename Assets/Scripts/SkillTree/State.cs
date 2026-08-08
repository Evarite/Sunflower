using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.SkillTree
{
    [System.Serializable]
    public class State
    {
        [Header("Finished Elements")]
        [SerializeField] private List<GameObject> _finishedUI;

        [Header("Button")]
        [SerializeField] private Button _purchaseButton;

        public Button PurchaseButton { get => _purchaseButton; }
        public List<GameObject> FinishedUI { get => _finishedUI; }

        public void SetFinishedUIActive()
        {
            _purchaseButton.gameObject.SetActive(false);

            foreach (var obj in _finishedUI)
                obj.SetActive(true);
        }
    }
}
