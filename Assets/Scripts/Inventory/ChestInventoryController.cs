using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventoryController
{
    private PlayerDataController _data;
    private InventoryView _view;
    private ChestOpenController _openController;
    
    public ChestInventoryController(InventoryView view, PlayerDataController data, ChestOpenController openController)
    {
        _view = view;
        _data = data;
        _openController = openController;
        _openController.reloadInventory += FillInventorySlots;
        FillInventorySlots();
    }

    public void FillInventorySlots()
    {
        Clearinventory();
        var count = 0;
        foreach(var item in _data.Data.ChestInventory)
        {
            var slot = _view.grid.transform.GetChild(count);
            var slotView = slot.GetComponent<InventoryChestSlotView>();
            slotView.preview.sprite = item.chestSprite;
            slotView.chest = item;
            slotView.countText.text = item._count.ToString();
            slotView.button.onClick.AddListener(delegate { StartOpenScript(slotView.chest); });
            count++;
        }
    }

    public void Clearinventory()
    {
        for(int i = 0; i < _view.grid.transform.childCount; i++)
        {
            var currentSlot = _view.grid.transform.GetChild(i).GetComponent<InventoryChestSlotView>();
            currentSlot.preview.sprite = _view.slotsBackground;
            currentSlot.chest = null;
            currentSlot.button.onClick.RemoveAllListeners();
            currentSlot.countText.text = 0.ToString();
        }
    }

    private void StartOpenScript(ChestInfo chest)
    {
        Debug.Log("Open start");
        _openController.ShowOpenScreen(chest);
    }
}
