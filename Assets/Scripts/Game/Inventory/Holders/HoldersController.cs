using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class HoldersController<T, U> : Controller<T, U> where T : InventoryView where U : HoldersModel
{
    public HoldersController(T view, U model) : base(view, model){}

    protected override void Init()
    {
        FillInventorySlots();
        _view.OnClick += HideScreen;
        _model.data.reloadInventory += FillInventorySlots;
    }

    public void FillInventorySlots()
    {
        var count = 0;
        foreach (var item in _model.data.Data.BonusCombinationInventory)
        {

            var slot = _view.grid.transform.GetChild(count);
            var slotView = slot.GetComponent<HoldersSlotView>();
            slotView.openButton.onClick.RemoveAllListeners();
            slotView.openButton.onClick.AddListener(delegate { StartCardReview(slotView); });
            slotView.firstCardPreview.sprite = item.cards[0].cardSprite;
            slotView.secondCardPreview.sprite = item.cards[1].cardSprite;
            slotView.thirdCardPreview.sprite = item.cards[2].cardSprite;
            if(!slotView.timerIsStart)
                slotView.StartTimer();
            count++;
        }
    }

    private void HideScreen()
    {
        _view.cardPositions.SetActive(false);
        _view.screenIsShow = false;
        _view.DestroyCard();
    }

    private void StartCardReview(HoldersSlotView combinationView)
    {
        _view.cardPositions.SetActive(true);
        if(!_view.screenIsShow)
        {
            _view.screenIsShow = true;
            _view.InstantiateNewCard(_model.cardPrefab);
            _view.currentCard.transform.GetChild(0).GetComponent<Image>().sprite = combinationView.firstCardPreview.sprite;
            _view.currentCard.transform.GetChild(1).GetComponent<Image>().sprite = combinationView.secondCardPreview.sprite;
            _view.currentCard.transform.GetChild(2).GetComponent<Image>().sprite = combinationView.thirdCardPreview.sprite;

            StartCardViewAnimation();
        }

    }

    private async UniTask StartCardViewAnimation()
    {
        await UIAnimations.SlideUpAnimation(_view.currentCard);
        for(int i = 0; i < 3; i++)
        {
            UIAnimations.SlideToPointAnimation(_view.cardPositions.transform.GetChild(i).gameObject.transform.position, _view.currentCard.transform.GetChild(i).gameObject.transform);
        }
    }
}
