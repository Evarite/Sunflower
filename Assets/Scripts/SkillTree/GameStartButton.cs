using Sunflower.Loading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.SkillTree
{
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("Sunflower/Skill Tree/Game Start Button")]
    public class GameStartButton : MonoBehaviour
    {
        [SerializeField] private SceneAsset _targetScene;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(StartGame);

        private void OnDisable() => _button.onClick.RemoveListener(StartGame);

        private void StartGame() => LoadingScreen.LoadScene(_targetScene.name);
    }
}
