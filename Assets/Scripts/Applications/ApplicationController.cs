using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    private UIController _uiController;
    private PlayerDataController _dataController;
    private MenuController<MenuView, MenuModel> _menuController;
    private ShopController<ShopView, ShopModel> _shopController;
    private CardInventoryController<InventoryView, CardInventoryModel> _cardInventoryController;
    private ChestInventoryController<InventoryView, ChestInventoryModel> _chestInventoryController;
    private CardController _cardController;
    private ChestOpenController<ChestOpenView, ChestOpenModel> _chestOpenController;

    [SerializeField] private List<CardInfo> allCards;
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
        _cardController = new CardController(allCards);
        _chestOpenController = GetComponent<ChestOpenApplication>().InstanceApplication(_dataController, _cardController);
        _cardInventoryController = GetComponent<CardInventoryApplication>().InstanceApplication(_dataController, _chestOpenController);
        _chestInventoryController = GetComponent<ChestInventoryApplication>().InstanceApplication(_dataController, _chestOpenController);
    }

    private void OnDestroy()
    {
        _dataController.Save();
    }
}
