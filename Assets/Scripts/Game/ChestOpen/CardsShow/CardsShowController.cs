using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class CardsShowController<T, U> : Controller<T, U> where T : CardsShowView where U : CardsShowModel
{
    public CardsShowController(T view, U model) : base(view, model){}

    protected override void Init()
    {
        base.Init();
        _model.cardRandomizer = new CardRandomizer(_model.allCards, _model.bonusCombinations);
    }

    private void EnableGoldenBorderInCards()
    {
        foreach (var card in _view.currentCardsCombination)
            card.GetComponent<CardView>().background.gameObject.SetActive(true);
    }

    public async UniTask StartMisteryBoxShow()
    {
        _view.showCardEffect.SetActive(true);
        var card = _model.cardRandomizer.GetRandomCard();
        await StartCardsShowContinuity(card, 1);
        _model.data.Data.CardInventory.Add(card);

        _view.DestroyCurrentCardCombination();
        _view.showCardEffect.SetActive(false);
    }

    public async UniTask StartCardsShow(bool isCrack)
    {
        _view.showCardEffect.SetActive(true);
        await UniTask.Delay(1000);
        FillWinCombination();

        var combinationType = GetRandomizeCombinationType();
        await ShowCardWithType(combinationType);
        if(isCrack)
            EnableCracks();
        await UniTask.Delay(1000);

        if(combinationType == CombinationType.bonus)
            _model.data.Data.BonusCombinationInventory.Add(_model.cardRandomizer._currentBonusCombination);


        _view.DestroyCurrentCardCombination();
        _view.DestroyCurrentWinCombination();
        _view.transform.GetChild(0).gameObject.SetActive(true);
        _view.showCardEffect.SetActive(false);
    }

    private void FillWinCombination()
    {
        var combination = _model.cardRandomizer.GetWinCombination();
        _view.InstantiateCardWinCombination(_model.winCombinationPref);
        for (int i = 0; i < 3; i++)
            _view.currentWinCombinationPref.transform.GetChild(i).GetComponent<Image>().sprite = combination[i].cardSprite;
    }

    private async UniTask ShowCardWithType(CombinationType type)
    {
        for (int i = 0; i < 3; i++)
        {
            if (type == CombinationType.win)
            {
                
                var card = _model.cardRandomizer._currentWinCombination[i];
                await StartCardsShowContinuity(card, i);
                _model.data.DepositToken(100);
            }
            else if (type == CombinationType.bonus)
            {
                Debug.Log("BonusCombinationInfo");
                var card = _model.cardRandomizer._currentBonusCombination.cards[i];
                await StartCardsShowContinuity(card, i);
                EnableGoldenBorderInCards();
            }
            else
            {
                var card = _model.cardRandomizer.GetRandomCard();
                await StartCardsShowContinuity(card, i);
            }
        }
    }

    private void EnableCracks()
    {
        foreach (var card in _view.currentCardsCombination)
            card.GetComponent<CardView>().cracks.gameObject.SetActive(true);
        Debug.Log(0);
    }

    private CombinationType GetRandomizeCombinationType()
    {
        var random = new System.Random();
        var randomIndex = random.Next(0, 100);

        Debug.Log(randomIndex);

        if (randomIndex < _model.currentChest.winChanceInProcent)
        {
            Debug.Log("Win Combination");
            _view.winCombinationAudio.Play();
            return CombinationType.win;

        }
        else if (randomIndex < _model.currentChest.bonusChanceInProcaent)
            return CombinationType.bonus;
        else
            return CombinationType.standart;
    }

    public async UniTask StartCardsShowContinuity(CardInfo card, int cardIndex)
    {
        _view.InstantiateNewCard(_model.cardPref);
        _view.currentCard.GetComponent<CardView>().preview.sprite = card.cardSprite;

        await UIAnimations.SlideUpAnimation(_view.currentCard);
        await UniTask.Delay(500);

        var position = _view.cardPositions.transform.GetChild(cardIndex).gameObject;
        await UIAnimations.SlideToPointAnimation(position.transform.position, _view.currentCard.transform);
        await UniTask.Delay(1000);
    }
}
