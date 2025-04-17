using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DataEngine
{
    public class GameRepository : IGameRepository
    {
        private const string SAVE_KEY = "SaveKey";
        private const string FILE_NAME = "savegame.json";
        private string FilePath => Path.Combine(Application.persistentDataPath, FILE_NAME);
        
        private Dictionary<string, string> _gameState = new();
        
        public bool TryGetData<T>(out T data)
        {
            string key = typeof(T).Name;

            if (_gameState.TryGetValue(key, out var jsonData))
            {
                data = JsonConvert.DeserializeObject<T>(jsonData);
                return true;
            }

            data = default;
            return false;
        }

        public void SetData<T>(T data)
        {
            string key = typeof(T).Name;
            _gameState[key] = JsonConvert.SerializeObject(data);
        }

        public void SaveState()
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(_gameState, Formatting.Indented);
                File.WriteAllText(FilePath, jsonData);
                Debug.Log($"Game saved to: {FilePath}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error saving game: {ex.Message}");
            }
        }

        public void LoadState()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    Debug.LogWarning("Save file not found");
                    return;
                }

                var jsonData = File.ReadAllText(FilePath);
                _gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
                Debug.Log("Game loaded successfully");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error loading game: {ex.Message}");
            }
        }
    }
}