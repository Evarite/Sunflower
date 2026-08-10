using Sunflower.Managers;
using Sunflower.Managers.Spawn;
using Sunflower.SaveSystem.Data;
using Sunflower.Seeds;
using Sunflower.SkillTree.EvolutionPoints;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [AddComponentMenu("Sunflower/Save/Game Save Loader")]
    public class GameSaveLoader : MonoBehaviour
    {
        [SerializeField] private SunflowerSave _sunflowerSave;
        [SerializeField] private EventsSave _eventsSave;
        [SerializeField] private ModuleSlotSpawnManager _slotManager;

        private void Start()
        {
            if (SaveManager.Instance.HasLoadedGame)
                return;

            GameSaveData data = SaveManager.Instance.Data;

            if (data == null)
            {
                Debug.LogWarning("No game data loaded.");
                return;
            }

            _sunflowerSave.ApplySaveData(data.SunflowerSaveData);

            _eventsSave.ApplySaveData(data.EventsSaveData);

            _slotManager.Load(SaveManager.Instance.Data.ModuleSaveData);

            SeedsCounter.Value = data.WealthSaveData.Seeds;

            EvoPointsCounter.Value = data.WealthSaveData.EvoPoints;

            PlayerStateManager.Instance.InitializeSkills(data.OwnedSkills);

            SaveManager.Instance.HasLoadedGame = true;
        }
    }
}