using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController
{
    private ShopView _view;
    private PlayerDataController _data;
    private UIController _ui;
    private ChestInventoryController _chestInventoryController;
    public ShopController(ShopView view, UIController ui, PlayerDataController data, ChestInventoryController chestController)
    {
        _data = data;
        _ui = ui;
        _view = view;
        _chestInventoryController = chestController;
        FillAllSlots();
    }


    public void FillAllSlots()
    {
        for(int i = 1; i < _view.grid.transform.childCount; i++)
        {
            var slot = _view.grid.transform.GetChild(i);
            var slotView = slot.GetComponent<ShopSlotView>();
            FillSlot(slotView);
            slotView.buyButton.onClick.AddListener(delegate { BuyChest(slotView.chest); });
        }

        var firstSlot = _view.grid.transform.GetChild(0);
        var keySlotView = firstSlot.GetComponent<ShopSlotView>();
        FillSlot(keySlotView);
        keySlotView.buyButton.onClick.AddListener(delegate { BuyKey(keySlotView.chest); });
        
    }

    private void FillSlot(ShopSlotView view)
    {
        view.textPrice.text = view.chest.price.ToString();
        view.preview.sprite = view.chest.chestSprite;
    }

    public void BuyKey(ChestInfo itemInfo)
    {
        if (itemInfo.price <= _data.Data.Token)
        {
            _data.Data.Token -= itemInfo.price;
            _data.Data.Keys++;
            _ui.UpdateTokenPanel();
            _ui.UpdateKeyPanel();
        }
    }

    public void BuyChest(ChestInfo itemInfo)
    {
        if(itemInfo.price <= _data.Data.Token)
        {
            _data.Data.Token -= itemInfo.price;
            _ui.UpdateTokenPanel();

            var duplicate = GetItemDuplicateInInventory(itemInfo);
            if (duplicate != null)
                duplicate._count++;
            else
                _data.Data.ChestInventory.Add(itemInfo);

            _chestInventoryController.FillInventorySlots();
        }
    }

    private ChestInfo GetItemDuplicateInInventory(ChestInfo item)
    {
        foreach(var inventoryItem in _data.Data.ChestInventory)
        {
            if(inventoryItem.chestName == item.chestName)
                return inventoryItem;
        }

        return null;
    }
}
