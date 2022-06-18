using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using ChestGame.Game.Animations;
using ChestGame.Data;
using ChestGame.Game.Module.ScriptableModule;
using ChestGame.Game.View;
using ChestGame.Game.Module.ScriptModule;

namespace ChestGame.Game.Controllers
{
    public class CardsShowController<T, U> : Controller<T, U> where T : CardsShowView where U : CardsDataBase
    {
        public CardsShowController(T view, U model) : base(view, model) { }

        protected override void Init()
        {
            base.Init();
            _model.CardRandomizer = new CardRandomizerModule(_model);
        }

        private void EnableGoldenBorderInCards()
        {
            foreach (var card in _view.CurrentCardsCombination)
                card.GetComponent<CardView>().Background.gameObject.SetActive(true);
        }

        public async UniTask StartMisteryBoxShow()
        {
            _view.ShowCardEffect.SetActive(true);
            var card = _model.CardRandomizer.GetRandomMisteryCard();
            await StartCardsShowContinuity(card, 1);
            _model.Data.PlayerData.CardInventory.Add(card);
            await UniTask.Delay(3000);
            _view.DestroyCurrentCardCombination();
            _view.ShowCardEffect.SetActive(false);
        }

        public async UniTask StartCardsShow(bool isCrack)
        {
            _view.ShowCardEffect.SetActive(true);
            await UniTask.Delay(1000);
            FillWinCombination();

            var combinationType = GetRandomizeCombinationType();
            await ShowCardWithType(combinationType);
            if (isCrack)
                EnableCracks();
            await UniTask.Delay(1000);

            if (combinationType == CombinationType.bonus)
                _model.Data.PlayerData.BonusCombinationInventory.Add(_model.CardRandomizer.CurrentBonusCombination);


            _view.DestroyCurrentCardCombination();
            _view.DestroyCurrentWinCombination();
            _view.transform.GetChild(0).gameObject.SetActive(true);
            _view.ShowCardEffect.SetActive(false);
        }

        private void FillWinCombination()
        {
            var combination = _model.CardRandomizer.GetWinCombination();
            _view.InstantiateCardWinCombination(_model.WinCombinationPref);
            for (int i = 0; i < 3; i++)
                _view.CurrentWinCombinationPref.transform.GetChild(i).GetComponent<Image>().sprite = combination[i].CardSprite;
        }

        private async UniTask ShowCardWithType(CombinationType type)
        {
            for (int i = 0; i < 3; i++)
            {
                if (type == CombinationType.win)
                {
                    var card = _model.CardRandomizer.CurrentWinCombination[i];
                    await StartCardsShowContinuity(card, i);
                    _model.Data.DepositToken(100);
                }
                else if (type == CombinationType.bonus)
                {
                    Debug.Log("BonusCombinationInfo");
                    var card = _model.CardRandomizer.CurrentBonusCombination.Combination.AllCards[i];
                    await StartCardsShowContinuity(card, i);
                    EnableGoldenBorderInCards();
                }
                else
                {
                    var card = _model.CardRandomizer.GetRandomCard();
                    await StartCardsShowContinuity(card, i);
                }
            }
        }

        private void EnableCracks()
        {
            foreach (var card in _view.CurrentCardsCombination)
                card.GetComponent<CardView>().Cracks.gameObject.SetActive(true);
            Debug.Log(0);
        }

        private CombinationType GetRandomizeCombinationType()
        {
            var random = new System.Random();
            var randomIndex = random.Next(0, 100);

            Debug.Log(randomIndex);

            if (randomIndex < _model.CurrentChest.WinChanceInProcent)
            {
                Debug.Log("Win Combination");
                _model.Data.Statistic.WinNumber++;
                _view.WinCombinationAudio.Play();
                return CombinationType.win;

            }
            else if (randomIndex < _model.CurrentChest.BonusChanceInProcaent)
            {
                _model.Data.Statistic.BonusNumber++;
                return CombinationType.bonus;

            }
            else
                return CombinationType.standart;
        }

        public async UniTask StartCardsShowContinuity(CardInfo card, int cardIndex)
        {
            _view.InstantiateNewCard(_model.CardPref);
            _view.CurrentCard.GetComponent<CardView>().Preview.sprite = card.CardSprite;

            await UIAnimations.SlideUpAnimation(_view.CurrentCard);
            await UniTask.Delay(500);

            var position = _view.CardPositions.transform.GetChild(cardIndex).gameObject;
            await UIAnimations.SlideToPointAnimation(position.transform.position, _view.CurrentCard.transform);
            await UniTask.Delay(1000);
        }
    }

}
