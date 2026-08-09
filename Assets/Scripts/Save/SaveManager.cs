using Sunflower.SaveSystem.Data;
using Sunflower.Seeds;
using Sunflower.SkillTree.EvolutionPoints;
using System;
using System.IO;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [AddComponentMenu("Sunflower/Save/Save Manager")]
    public class SaveManager : MonoBehaviour
    {
        //modules
        [Header("Save Path")]
        [Tooltip("Путь сохранения в документах")]
        [SerializeField] private string _savePath;

        [Header("Save Handlers")]
        [SerializeField] private SunflowerSave _sunflowerSave;
        [SerializeField] private EventsSave _eventsSave;

        private string SavePath =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _savePath);

        public void Save()
        {
            var data = new GameSaveData
                (
                _sunflowerSave.Save(),
                new WealthSaveData(SeedsCounter.Value, EvoPointsCounter.Value),
                _eventsSave.Save()
                );

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(SavePath, json);
        }

        public void Load()
        {

        }
    }
}