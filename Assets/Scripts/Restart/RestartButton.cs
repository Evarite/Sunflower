using Sunflower.Growth;
using Sunflower.Loading;
using Sunflower.Managers;
using Sunflower.SkillTree.EvolutionPoints;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.Restart
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private SunflowerGrowth _sunflowerGrowth;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(RestartGame);

        private void OnDisable() => _button.onClick.RemoveListener(RestartGame);

        private void RestartGame()
        {
            int points = CalculateEvoPoints.Calculate(_sunflowerGrowth.Height);
            PlayerStateManager.Instance.PointsEarned = points;
            Debug.Log("Points Earned: " + PlayerStateManager.Instance.PointsEarned);

            EvoPointsCounter.Value += PlayerStateManager.Instance.PointsEarned;

            LoadingScreen.LoadScene("SkillTree");
        }
    }
}