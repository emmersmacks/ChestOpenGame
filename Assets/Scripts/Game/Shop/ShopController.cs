using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController<T, U>: Controller<T, U> where T : ShopView where U : ShopModel
{
    public ShopController(T view, U model) : base(view, model){}

    protected override void Init()
    {
        base.Init();
        FillAllSlots();
    }

    public void FillAllSlots()
    {
        var firstSlot = _view.grid.transform.GetChild(0);
        var keySlotView = firstSlot.GetComponent<ShopSlotView>();
        FillSlot(keySlotView);
        keySlotView.buyButton.onClick.RemoveAllListeners();
        keySlotView.buyButton.onClick.AddListener(delegate { BuyKey(keySlotView.chest); });
    }

    private void FillSlot(ShopSlotView view)
    {
        view.textPrice.text = view.chest.price.ToString();
        view.preview.sprite = view.chest.chestSprite;
    }

    private void BuyKey(ChestInfo itemInfo)
    {
        if (itemInfo.price <= _model.data.Data.Token)
        {
            Debug.Log("Buyed");
            _model.data.DebitingToken(itemInfo.price);
            _model.data.DepositKey(1);
        }
    }

    private void BuyChest(ChestInfo itemInfo)
    {
        if(itemInfo.price <= _model.data.Data.Token)
        {
            _model.data.DebitingToken(itemInfo.price);
            CheckOnDuplicate(itemInfo);
            _model.chestInventoryController.FillInventorySlots();
        }
    }

    private void CheckOnDuplicate(ChestInfo itemInfo)
    {
        var duplicate = GetItemDuplicateInInventory(itemInfo);
        if (duplicate != null)
            duplicate._count++;
        else
            _model.data.Data.ChestInventory.Add(itemInfo);
    }

    private ChestInfo GetItemDuplicateInInventory(ChestInfo item)
    {
        foreach(var inventoryItem in _model.data.Data.ChestInventory)
        {
            if(inventoryItem.chestName == item.chestName)
                return inventoryItem;
        }
        return null;
    }
}
