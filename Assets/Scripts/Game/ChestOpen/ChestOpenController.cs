using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using System;

public class ChestOpenController<T, U> : Controller<T, U> where T : ChestOpenView where U : ChestOpenModel
{
    public Action reloadInventory = default;

    public ChestOpenController(T view, U model) : base(view, model){}

    protected override void Init()
    {
        base.Init();
    }

    public void ShowOpenScreen(ChestInfo chest)
    {
        var screen = _view.gameObject.transform.GetChild(0).gameObject;
        screen.transform.position = new Vector3(0, -10, 0);
        OpenChestAnimations.SlideUpAnimation(screen);
        _model.currentChest = chest;
        if (_model.currentChest.chestName != _model.defaultChest.chestName)
            _view.upgradeButton.gameObject.SetActive(false);
        else
            _view.upgradeButton.gameObject.SetActive(true);
        _view.gameObject.SetActive(true);
        FillOpenScreenData();
    }

    public async UniTask CloseOpenScreen()
    {
        await OpenChestAnimations.WindowSlideDownAnimation(_view.gameObject.transform.GetChild(0).gameObject);
        _view.gameObject.SetActive(false);
    }

    public void FillOpenScreenData()
    {
        _view.closeButton.onClick.RemoveAllListeners();
        _view.openButton.onClick.RemoveAllListeners();
        _view.hackButton.onClick.RemoveAllListeners();
        _view.upgradeButton.onClick.RemoveAllListeners();

        _view.preview.sprite = _model.currentChest.chestSprite;
        _view.closeButton.onClick.AddListener(delegate { CloseOpenScreen(); });
        _view.openButton.onClick.AddListener(delegate {OpenStart(); });
        _view.hackButton.onClick.AddListener(HackStart);
        _view.upgradeButton.onClick.AddListener(ChestUpgrade);
    }

    public void ChestUpgrade()
    {
        _model.data.Data.ChestInventory.Add(_model.upgradeChest);
        reloadInventory();
    }

    private async UniTask OpenStart()
    {
        if(_model.data.Data.Keys > 0)
        {
            _view.openChestEffect.SetActive(true);
            var openChestScreen = _view.transform.GetChild(0).gameObject;
            await OpenChestAnimations.WindowSlideDownAnimation(openChestScreen);
            _view.showCardEffect.SetActive(true);
            await UniTask.Delay(1000);
            openChestScreen.SetActive(false);
            openChestScreen.transform.position = Vector3.zero;

            _model.data.DebitingKey(1);

            if (_model.currentChest.chestName == _model.upgradeChest.chestName)
            {
                Debug.Log("Upgrade chest open!");
                await StartMisteryBoxShow();
            }
            else
            {
                await StartCardsShow();
            }

            _view.showCardEffect.SetActive(false);
            _view.openChestEffect.SetActive(false); 
        }
        else
        {
            Debug.Log("Not enougfjnkg key");
        }
    }

    private async UniTask FillWinCombination()
    {
        var combination = _model.cardController.GetWinCombination();
        _view.InstantiateCardCombination(_model.winCombinationPref);
        for(int i = 0; i < 3; i++)
        {
            _view.currentWinCombinationPref.transform.GetChild(i).GetComponent<Image>().sprite = combination[i].cardSprite;
        }
    }

    private async UniTask StartMisteryBoxShow()
    {
        var card = _model.cardController.GetRandomCard();
        await StartCardsShowAnimation(card, 1);
        _model.data.Data.CardInventory.Add(card);
        Debug.Log(_model.data.Data.ChestInventory.Count);

        for (var i = 0; i < _model.data.Data.ChestInventory.Count; i++)
        {
            if (_model.data.Data.ChestInventory[i].chestName == _model.currentChest.chestName)
            {
                _model.data.Data.ChestInventory.RemoveAt(i);
                break;
            }
        }
        reloadInventory();
        _view.DestroyCurrentCardCombination();
        _view.transform.GetChild(0).gameObject.SetActive(true);
        CloseOpenScreen();
    }

    private async UniTask StartCardsShow()
    {
        await FillWinCombination();

        var isWinCombination = false;

        var random = new System.Random();
        var randomIndex = random.Next(0, 100);
        if (randomIndex < _model.currentChest.winChanceInProcent)
        {
            isWinCombination = true;
            Debug.Log("Win combination!!");
        }

        for (int i = 0; i < 3; i++)
        {
            if(isWinCombination)
            {
                var card = _model.cardController._currentWinCombination[i];
                await StartCardsShowAnimation(card, i);
            }
            else
            {
                var card = _model.cardController.GetRandomCard();
                await StartCardsShowAnimation(card, i);
            }
        }

        if (isWinCombination)
            _model.data.DepositToken(100);

        _view.DestroyCurrentCardCombination();
        _view.DestroyCurrentWinCombination();
        _view.transform.GetChild(0).gameObject.SetActive(true);
    }

    public async UniTask StartCardsShowAnimation(CardInfo card, int cardIndex)
    {
        _view.InstantiateNewCard(_model.cardPref);
        _view.currentCard.GetComponent<Image>().sprite = card.cardSprite;

        await OpenChestAnimations.SlideUpAnimation(_view.currentCard);
        await UniTask.Delay(500);
        await OpenChestAnimations.SlideToPointAnimation(_view, cardIndex);
        await UniTask.Delay(1000);
    }

    private void HackStart()
    {
        StartCardsShow();
    }
}
