using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventoryController<T, U> : Controller<T, U> where T : InventoryView where U : CardInventoryModel
{
    public CardInventoryController(T view, U model) : base(view, model){}

    protected override void Init()
    {
        _model.chestOpenController.reloadInventory += FillInventorySlots;
        FillInventorySlots();
    }

    public void FillInventorySlots()
    {
        var count = 0;
        foreach (var item in _model.data.Data.CardInventory)
        {
            var slot = _view.grid.transform.GetChild(count);
            var slotView = slot.GetComponent<InventoryCardsSlotView>();
            slotView.preview.sprite = item.cardSprite;
            slotView.card = item;
            count++;
        }
    }
}
