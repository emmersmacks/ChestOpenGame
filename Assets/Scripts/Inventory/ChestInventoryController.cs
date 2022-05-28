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
        FillInventorySlots();
    }

    public void FillInventorySlots()
    {
        var count = 0;
        foreach(var item in _data.Data.ChestInventory)
        {
            var slot = _view.grid.transform.GetChild(count);
            var slotView = slot.GetComponent<InventorySlotView>();
            slotView.preview.sprite = item.chestSprite;
            slotView.chest = item;
            slotView.countText.text = item._count.ToString();
            slotView.button.onClick.AddListener(delegate { StartOpenScript(slotView.chest); });
            count++;
        }
    }

    private void StartOpenScript(ChestInfo chest)
    {
        _openController.ShowOpenScreen(chest);
    }
}
