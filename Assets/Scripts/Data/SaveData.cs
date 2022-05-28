using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveData
{
    private const string dataPath = "/PlayerData";

    public static void SaveToJson(PlayerData data)
    {
        var stringData = JsonUtility.ToJson(data);
        File.WriteAllText(dataPath, stringData);
    }
}
