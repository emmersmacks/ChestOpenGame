using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PlayerDataController
{
    private const string dataPath = "/PlayerData";
    public PlayerData Data { get; set; }

    public void Load()
    {
        if (File.Exists(dataPath))
            Data = LoadData.LoadFromJson();
        else
            SetDefoultValues();
    }

    public void Save()
    {
        SaveData.SaveToJson(Data);
    }

    public void SetDefoultValues()
    {
        if(Data == null)
        {
            Data = new PlayerData();
        }

        Debug.Log("First start");
        Data.Token = 100;
        Data.Diamond = 100;
        Data.Keys = 0;
        Data.MasterKeys = 5;
        Data.CardInventory = new List<CardInfo>();
        Data.ChestInventory = new List<ChestInfo>();
    }
}

public class PlayerData
{
    public int Token { get; set; }
    public int Diamond { get; set; }
    public int Keys { get; set; }
    public int MasterKeys { get; set; }

    public List<ChestInfo> ChestInventory { get; set; }
    public List<CardInfo> CardInventory { get; set; }

    public DateTime LastExitTime { get; set; }
}
