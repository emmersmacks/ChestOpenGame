using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class ChestOpenController
{
    private ChestOpenView _view;
    private PlayerDataController _data;
    private UIController _ui;
    private CardController _cardController;

    private ChestInfo _currentChest;

    public ChestOpenController(ChestOpenView view, PlayerDataController data, UIController ui, CardController cardController)
    {
        _view = view;
        _data = data;
        _ui = ui;
        _cardController = cardController;
    }

    public void ShowOpenScreen(ChestInfo chest)
    {
        _currentChest = chest;
        _view.gameObject.SetActive(true);
        FillOpenScreenData();
    }

    public void CloseOpenScreen()
    {
        _view.gameObject.SetActive(false);
    }

    public void FillOpenScreenData()
    {
        _view.preview.sprite = _currentChest.chestSprite;
        _view.closeButton.onClick.AddListener(CloseOpenScreen);
        _view.openButton.onClick.AddListener(OpenStart);
        _view.hackButton.onClick.AddListener(HackStart);
    }

    private void OpenStart()
    {
        _view.transform.GetChild(0).gameObject.SetActive(false);

        _data.Data.Keys--;
        _ui.UpdateKeyPanel();
        FillWinCombination();
        StartCardsShow();
    }

    private void FillWinCombination()
    {
        var combination = _cardController.GetWinCombination();
        _view.InstantiateCardCombination();
        for(int i = 0; i < 3; i++)
        {
            _view.currentCombination.transform.GetChild(i).GetComponent<Image>().sprite = combination[i].cardSprite;
        }
    }

    private async UniTask StartCardsShow()
    {
        for (int i = 0; i < 3; i++)
        {
            var card = _cardController.GetRandomCard();
            _data.Data.CardInventory.Add(card);
            await StartCardsShowAnimation(card);
        }
        _view.DestroyCurrentCombination();
        _view.transform.GetChild(0).gameObject.SetActive(true);
    }

    public async UniTask StartCardsShowAnimation(CardInfo card)
    {
        _view.InstantiateNewCard();
        _view.currentCard.GetComponent<Image>().sprite = card.cardSprite;
        await UniTask.Delay(2000);
        _view.DestroyCurrentCard();
    }

    private void HackStart()
    {

    }
}
