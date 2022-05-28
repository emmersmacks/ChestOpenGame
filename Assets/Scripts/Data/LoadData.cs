using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class LoadData
{
    private const string dataPath = "/PlayerData";

    public static PlayerData LoadFromJson()
    {
        string fileData = File.ReadAllText(dataPath);
        PlayerData data = JsonUtility.FromJson<PlayerData>(fileData);
        return data;
    }
}
