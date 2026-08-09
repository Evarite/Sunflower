using Sunflower.Loading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.SaveSystem
{
    [RequireComponent(typeof(Button))]
    public class EnterGame : MonoBehaviour
    {
        [SerializeField] private SceneAsset _scene;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(EnterGameScene);

        private void OnDisable() => _button.onClick.RemoveListener(EnterGameScene);

        private void EnterGameScene()
        {
            LoadingScreen.LoadScene(_scene.name);
        }
    }
}