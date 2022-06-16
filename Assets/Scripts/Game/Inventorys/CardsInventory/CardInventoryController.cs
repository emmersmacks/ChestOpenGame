using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CardInventoryController<T, U> : Controller<T, U> where T : CardsInventoryView where U : CardInventoryModel
{
    public CardInventoryController(T view, U model) : base(view, model){}

    private InventoryCardsSlotView currentSlot;

    protected override void Init()
    {
        _model.data.reloadInventory += FillInventorySlots;
        _view.closePresenterButton.onClick.AddListener(HideScreen);
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
            slotView.button.onClick.RemoveAllListeners();
            slotView.button.onClick.AddListener(delegate { StartCardViewAnimation(slotView); });
            count++;
        }
    }

    private async UniTask StartCardViewAnimation(InventoryCardsSlotView viewSlot)
    {
        _view.closePresenterButton.gameObject.SetActive(true);
        currentSlot = viewSlot;
        _view.closePresenterButton.enabled = true;
        viewSlot.button.enabled = false;
        _view.ScreenIsShow = true;
        _model.CurrentCard = _view.cardPresenterModule.InstantiateNewCard(_model.cardPrefab);
        await UIAnimations.SlideUpAnimation(_model.CurrentCard);
        for (int i = 0; i < 3; i++)
        {
            UIAnimations.SlideToPointAnimation(_view.cardPositions.transform.GetChild(1).gameObject.transform.position, _model.CurrentCard.transform.GetChild(i).gameObject.transform);
        }
    }

    private void HideScreen()
    {
        _view.closePresenterButton.gameObject.SetActive(false);
        currentSlot.button.enabled = true;
        _view.cardPositions.SetActive(false);
        _view.ScreenIsShow = false;
        _view.cardPresenterModule.DestroyCard(_model.CurrentCard);
        _view.closePresenterButton.enabled = false;

    }
}
