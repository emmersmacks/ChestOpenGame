using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace ChestGame.Data
{
    public static class SaveData
    {
        private const string _dataPath = "/PlayerData";

        public static void SaveToJson(PlayerData data)
        {
            var stringData = JsonUtility.ToJson(data);
            File.WriteAllText(_dataPath, stringData);
        }
    }
}

