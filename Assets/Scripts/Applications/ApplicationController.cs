using ChestGame.Data;
using ChestGame.Game.Controllers;
using ChestGame.Game.Models;
using ChestGame.Game.Module.ScriptableModule;
using ChestGame.Game.View;
using UnityEngine;

namespace ChestGame.Game.Applications
{
    public class ApplicationController : MonoBehaviour
    {
        private UIController _uiController;
        private PlayerDataController _dataController;

        [SerializeField] private ChestInfo defaultChest;

        private void Start()
        {
            _uiController = GetComponent<UIApplication>().InstanceApplication();
            _dataController = GetComponent<DataApplication>().InstanceApplication(_uiController);
            _uiController.Init(_dataController);
            _dataController.PlayerData.ChestInventory.Add(defaultChest);

            SetAllApplications();
        }

        private void SetAllApplications()
        {
            GetComponent<MenuApplication>().InstantiateApplication();
            GetComponent<ShopApplication>().InstanceApplication(_dataController);
            GetComponent<CardInventoryApplication>().InstanceApplication(_dataController);
            GetComponent<ChestInventoryApplication>().InstanceApplication(_dataController);
            GetComponent<HoldersInventoryApplication>().InstanceApplication(_dataController);
        }

        private void OnDestroy()
        {
            _dataController.Save();
        }
    }
}


