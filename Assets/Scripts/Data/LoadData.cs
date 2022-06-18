using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace ChestGame.Data
{
    public static class LoadData
    {
        private const string _dataPath = "/PlayerData";

        public static PlayerData LoadFromJson()
        {
            string fileData = File.ReadAllText(_dataPath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(fileData);
            return data;
        }
    }
}

