using Sunflower.SaveSystem.Data;
using Sunflower.Seeds;
using Sunflower.SkillTree.EvolutionPoints;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    public class SaveManager : MonoBehaviour
    {
        //modules
        [SerializeField] private SunflowerSave _sunflowerSave;
        //[SerializeField] private

        public void Save()
        {
            var data = new GameSaveData
                (
                _sunflowerSave.Save(),
                new WealthSaveData(SeedsCounter.Value, EvoPointsCounter.Value),
                new EventsSaveData()
                );

            string json = JsonUtility.ToJson(data, true);
        }

        public void Load()
        {

        }
    }
}