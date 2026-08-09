using Sunflower.Input;
using Sunflower.Loading;
using Sunflower.SaveSystem.Data;
using Sunflower.Seeds;
using Sunflower.SkillTree.EvolutionPoints;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sunflower.SaveSystem
{
    [AddComponentMenu("Sunflower/Save/Exit To Menu")]
    public class ExitToMenuHandler : MonoBehaviour
    {
        [Header("Save Data")]
        [SerializeField] private SunflowerSave _sunflowerSave;
        [SerializeField] private EventsSave _eventsSave;

        private ExitToMenu _exit;

        private void Awake() => _exit = new();

        private void OnEnable()
        {
            _exit.Player.ExitToMenu.performed += ExitToMenu;
            _exit.Player.Enable();
        }

        private void OnDisable()
        {
            _exit.Player.ExitToMenu.performed -= ExitToMenu;
            _exit.Player.Disable();
        }

        private void ExitToMenu(InputAction.CallbackContext callbackContext)
        {
            var data = new GameSaveData(
                _sunflowerSave.GetSaveData(),
                new WealthSaveData(
                    SeedsCounter.Value,
                    EvoPointsCounter.Value
                ),
                _eventsSave.GetSaveData()
            );

            SaveManager.Instance.SaveGame(data);

            LoadingScreen.LoadScene("Menu");
        }
    }
}