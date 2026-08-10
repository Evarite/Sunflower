using Sunflower.Loading;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.SaveSystem
{
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("Sunflower/Save/Enter Game")]
    public class EnterGame : MonoBehaviour
    {
        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(EnterGameScene);

        private void OnDisable() => _button.onClick.RemoveListener(EnterGameScene);

        private void EnterGameScene()
        {
            SaveManager.Instance.LoadGame();

            LoadingScreen.LoadScene("GameScene");
        }
    }
}