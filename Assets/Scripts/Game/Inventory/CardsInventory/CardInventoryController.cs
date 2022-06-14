using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CardInventoryController<T, U> : Controller<T, U> where T : InventoryView where U : CardInventoryModel
{
    public CardInventoryController(T view, U model) : base(view, model){}

    protected override void Init()
    {
        _model.data.reloadInventory += FillInventorySlots;
        _view.OnClick += HideScreen;
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
            slotView.button.onClick.AddListener(delegate { StartCardViewAnimation(slotView); });
            count++;
        }
    }

    private async UniTask StartCardViewAnimation(InventoryCardsSlotView viewSlot)
    {
        _view.screenIsShow = true;
        _view.InstantiateNewCard(_model.cardPrefab);
        await UIAnimations.SlideUpAnimation(_view.currentCard);
        for (int i = 0; i < 3; i++)
        {
            UIAnimations.SlideToPointAnimation(_view.cardPositions.transform.GetChild(1).gameObject.transform.position, _view.currentCard.transform.GetChild(i).gameObject.transform);
        }
    }

    private void HideScreen()
    {
        _view.cardPositions.SetActive(false);
        _view.screenIsShow = false;
        _view.DestroyCard();
    }
}
