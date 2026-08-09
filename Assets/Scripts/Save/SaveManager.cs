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

        private GameSaveData _data;

        public GameSaveData Data
        {
            get
            {
                var val = HasLoadedGame ? null : _data;
                HasLoadedGame = true;
                return val;
            }
            private set => _data = value;
        }

        public bool HasLoadedGame { get; private set; } = false;

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

                return;
            }

            string json = File.ReadAllText(SavePath);

            Data = JsonUtility.FromJson<GameSaveData>(json);
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