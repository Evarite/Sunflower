using Sunflower.SaveSystem.Data;
using System;
using System.IO;
using UnityEngine;

namespace Sunflower.SaveSystem
{
    [AddComponentMenu("Sunflower/Save/Save Manager")]
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }

        [Header("Save Path")]
        [Tooltip("Путь сохранения в документах")]
        [SerializeField] private string _savePath = "Sunflower/save.json";

        private string SavePath =>
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                _savePath
            );

        public GameSaveData Data { get; private set; }

        public bool HasLoadedGame { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadGame()
        {
            if (HasLoadedGame)
                return;

            if (!File.Exists(SavePath))
            {
                Data = new GameSaveData(
                    new SunflowerSaveData(0f, new()),
                    new WealthSaveData(0, 0),
                    new EventsSaveData()
                );

                HasLoadedGame = true;
                return;
            }

            string json = File.ReadAllText(SavePath);

            Data = JsonUtility.FromJson<GameSaveData>(json);

            HasLoadedGame = true;
        }

        public void SaveGame(GameSaveData data)
        {
            HasLoadedGame = false;

            string json = JsonUtility.ToJson(data, true);

            string directory = Path.GetDirectoryName(SavePath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(SavePath, json);
        }
    }
}