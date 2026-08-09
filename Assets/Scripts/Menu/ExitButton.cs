using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.Menu
{
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("Sunflower/Menu/Exit Button")]
    public class ExitButton : MonoBehaviour
    {
        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(Exit);

        private void OnDisable() => _button.onClick.RemoveListener(Exit);

        private void Exit()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}