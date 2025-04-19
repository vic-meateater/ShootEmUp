using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DataEngine
{
    public sealed class GameRepository : IGameRepository
    {
        private const string SAVE_KEY = "SaveKey";
        private const string FILE_NAME = "savegame.json";
        private string FilePath => Path.Combine(Application.persistentDataPath, FILE_NAME);
        
        private Dictionary<string, string> _gameState = new();
        
        public bool TryGetData<T>(out T data)
        {
            string key = typeof(T).Name;

            if (_gameState.TryGetValue(key, out var encryptedJsonData))
            {
                string jsonData = Encryptor.Decrypt(encryptedJsonData);
                data = JsonConvert.DeserializeObject<T>(jsonData);
                return true;
            }

            data = default;
            return false;
        }

        public void SetData<T>(T data)
        {
            string key = typeof(T).Name;
            string json = JsonConvert.SerializeObject(data);
            _gameState[key] = Encryptor.Encrypt(json);
        }

        public void SaveState()
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(_gameState, Formatting.Indented);
                string encryptedData = Encryptor.Encrypt(jsonData);
                File.WriteAllText(FilePath, encryptedData);
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

                var encryptedData = File.ReadAllText(FilePath);
                string jsonData = Encryptor.Decrypt(encryptedData);
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