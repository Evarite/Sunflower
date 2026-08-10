using Sunflower.Growth;
using Sunflower.Managers;
using UnityEngine;

namespace Sunflower.MetaProgression
{
    public class Death : MonoBehaviour
    {
        [SerializeField] private GameObject _loseScreen;
        [SerializeField] private SunflowerGrowth _growth;

        private void Awake() => _loseScreen.SetActive(false);

        private void OnEnable() => LoseManager.Lost += Die;

        private void OnDisable() => LoseManager.Lost -= Die;

        private void Die()
        {
            _loseScreen.SetActive(true);
            _growth.Modifiers.Add(0);
        }
    }
}