using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    internal UIController _uiController;
    internal PlayerDataController _dataController;
    internal MenuController<MenuView, MenuModel> _menuController;
    internal ShopController<ShopView, ShopModel> _shopController;
    internal CardInventoryController<InventoryView, CardInventoryModel> _cardInventoryController;
    internal ChestInventoryController<InventoryView, ChestInventoryModel> _chestInventoryController;
    internal HoldersController<InventoryView, HoldersModel> _holdersController;

    [SerializeField] private ChestInfo defaultChest;

    private void Start()
    {
        _uiController = GetComponent<UIApplication>().InstanceApplication();
        _dataController = GetComponent<DataApplication>().InstanceApplication(_uiController);
        _uiController.Init(_dataController);
        _dataController.Data.ChestInventory.Add(defaultChest);
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
