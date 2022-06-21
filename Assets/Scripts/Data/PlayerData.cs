using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using ChestGame.Game.Module.ScriptableModule;
using ChestGame.Game.Controllers;

namespace ChestGame.Data
{
    public class PlayerDataController
    {
        public PlayerData PlayerData { get; set; }
        public StatisticData Statistic { get; set; }
        public SystemData SystemData { get; set; }
        
        private UIController _ui;
        private const string _dataPath = "/PlayerData";

        public PlayerDataController(UIController ui)
        {
            _ui = ui;
            Load();
        }

        public void DebitingToken(int number)
        {
            if (PlayerData.Token >= number)
                PlayerData.Token -= number;
            _ui.UpdateTokenPanel(this);
        }

        public void DebitingKey(int number)
        {
            if (PlayerData.Keys >= number)
                PlayerData.Keys -= number;
            _ui.UpdateKeyPanel(this);
        }

        public void DebitingMasterKey(int number)
        {
            if (PlayerData.MasterKeys >= number)
                PlayerData.MasterKeys -= number;
            _ui.UpdateMasterKeyPanel(this);
        }

        public void DepositKey(int number)
        {
            PlayerData.Keys += number;
            _ui.UpdateKeyPanel(this);
        }

        public void DepositToken(int number)
        {
            PlayerData.Token += number;
            _ui.UpdateTokenPanel(this);
        }

        public void DepositMasterKey(int number)
        {
            PlayerData.MasterKeys += number;
            _ui.UpdateMasterKeyPanel(this);
        }

        public void Load()
        {
            if (File.Exists(_dataPath))
                PlayerData = LoadData.LoadFromJson();
            else
                SetDefoultValues();
        }

        public void Save()
        {
            SaveData.SaveToJson(PlayerData);
        }

        public void SetDefoultValues()
        {
            if (PlayerData == null)
                PlayerData = new PlayerData();

            if (Statistic == null)
                Statistic = new StatisticData();

            if (SystemData == null)
                SystemData = new SystemData();

            Debug.Log("First start");
            PlayerData.Token = 100;
            PlayerData.Diamond = 100;
            PlayerData.Keys = 0;
            PlayerData.MasterKeys = 5;
            PlayerData.CardInventory = new List<CardInfo>();
            PlayerData.ChestInventory = new List<ChestInfo>();
            PlayerData.BonusCombinationInventory = new List<BonusCombinationInfo>();
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
}

