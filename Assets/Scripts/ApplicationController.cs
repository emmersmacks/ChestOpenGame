using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    private PlayerDataController _data;
    [SerializeField] private UIView _uiView;
    [SerializeField] private MenuView _menuView;
    [SerializeField] private InventoryView _cardsInventoryView;
    [SerializeField] private InventoryView _chestsInventoryView;
    [SerializeField] private ShopView _shopView;
    [SerializeField] private InventoryView _inventoryChestView;
    [SerializeField] private ChestOpenView _chestOpenView;
    [SerializeField] private List<CardInfo> allCards;
    [SerializeField] private ChestInfo defaultChest;

    private void Start()
    {
        _data = new PlayerDataController();
        _data.Load();
        _data.Data.ChestInventory.Add(defaultChest);
        InitControllers();
    }

    private void OnDestroy()
    {
        _data.Save();
    }

    private void InitControllers()
    {
        var ui = new UIController(_uiView, _data);
        var menu = new MenuController(_menuView);
        var cardController = new CardController(allCards);
        var chestOpen = new ChestOpenController(_chestOpenView, _data, ui, cardController);
        var chestInventory = new ChestInventoryController(_inventoryChestView, _data, chestOpen);
        var cardInventory = new CardInventoryController(_cardsInventoryView, _data, chestOpen);
        var shop = new ShopController(_shopView, ui, _data, chestInventory);
    }
}
