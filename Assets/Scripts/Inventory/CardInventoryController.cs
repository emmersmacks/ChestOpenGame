using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventoryController
{
    private InventoryView _view;
    private PlayerDataController _data;
    public CardInventoryController(InventoryView view, PlayerDataController data, ChestOpenController chestOpen)
    {
        _view = view;
        _data = data;

        chestOpen.reloadInventory += FillInventorySlots;
        FillInventorySlots();
    }

    public void FillInventorySlots()
    {
        var count = 0;
        foreach (var item in _data.Data.CardInventory)
        {
            var slot = _view.grid.transform.GetChild(count);
            var slotView = slot.GetComponent<InventoryCardsSlotView>();
            slotView.preview.sprite = item.cardSprite;
            slotView.card = item;
            count++;
        }
    }
}
