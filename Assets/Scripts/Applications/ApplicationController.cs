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
        private MenuController<MenuView, MenuModel> _menuController;
        private ShopController<ShopView, ShopModel> _shopController;
        private CardInventoryController<CardsInventoryView, CardInventoryModel> _cardInventoryController;
        private ChestInventoryController<ChestInventoryView, ChestInventoryModel> _chestInventoryController;
        private HoldersInventoryController<HoldersInventoryView, HoldersModel> _holdersController;

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
            _menuController = GetComponent<MenuApplication>().InstantiateApplication();
            _shopController = GetComponent<ShopApplication>().InstanceApplication(_dataController);
            _cardInventoryController = GetComponent<CardInventoryApplication>().InstanceApplication(_dataController);
            _chestInventoryController = GetComponent<ChestInventoryApplication>().InstanceApplication(_dataController);
            _holdersController = GetComponent<HoldersInventoryApplication>().InstanceApplication(_dataController);
        }

        private void OnDestroy()
        {
            _dataController.Save();
        }
    }
}


