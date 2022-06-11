using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventoryController<T, U> : Controller<T, U> where T : InventoryView where U : ChestInventoryModel
{
    public ChestInventoryController(T view, U model) : base(view, model){}

    public ChestOpenController<ChestOpenView, ChestOpenModel> chestOpenController { get; set; }

    protected override void Init()
    {
        base.Init();
        _model.data.reloadInventory += FillInventorySlots;

        FillInventorySlots();
    }

    public void FillInventorySlots()
    {
        Clearinventory();
        var count = 0;
        foreach(var item in _model.data.Data.ChestInventory)
        {
            var slot = _view.grid.transform.GetChild(count);
            var slotView = slot.GetComponent<InventoryChestSlotView>();
            slotView.preview.sprite = item.chestSprite;
            slotView.chest = item;
            slotView.button.onClick.AddListener(delegate { StartOpenScript(slotView); });
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
        }
    }

    private void StartOpenScript(InventoryChestSlotView slot)
    {
        var model = Resources.Load<ChestOpenModel>("ChestOpenModel");
        model.slotView = slot;
        model.currentChest = slot.chest;
        model.data = _model.data;
        model.inventory = _view.grid;

        chestOpenController = new ChestOpenController<ChestOpenView, ChestOpenModel>(_view.chestOpenView, model);
        
    }
}
