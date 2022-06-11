using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PlayerDataController
{
    private const string dataPath = "/PlayerData";
    public PlayerData Data { get; set; }

    private UIController _ui;
    public Action reloadInventory = default;
    public PlayerDataController(UIController ui)
    {
        _ui = ui;
        Load();
    }

    public void DebitingToken(int number)
    {
        if(Data.Token >= number)
            Data.Token -= number;
        _ui.UpdateTokenPanel(this);
    }

    public void DebitingKey(int number)
    {
        if (Data.Keys >= number)
            Data.Keys -= number;
        _ui.UpdateKeyPanel(this);
    }

    public void DebitingMasterKey(int number)
    {
        if (Data.MasterKeys >= number)
            Data.MasterKeys -= number;
        _ui.UpdateMasterKeyPanel(this);
    }

    public void DepositKey(int number)
    {
        Data.Keys += number;
        _ui.UpdateKeyPanel(this);
    }

    public void DepositToken(int number)
    {
        Data.Token += number;
        _ui.UpdateTokenPanel(this);
    }

    public void DepositMasterKey(int number)
    {
        Data.MasterKeys += number;
        _ui.UpdateMasterKeyPanel(this);
    }

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
        Data.BonusCombinationInventory = new List<BonusCombinationInfo>();
        _ui.ArrowTrainingStart();
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
    public List<BonusCombinationInfo> BonusCombinationInventory { get; set; }

    public DateTime LastExitTime { get; set; }
}
