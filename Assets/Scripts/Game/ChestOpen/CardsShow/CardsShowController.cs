using UnityEngine;
using Cysharp.Threading.Tasks;
using ChestGame.Game.Animations;
using ChestGame.Game.Module.ScriptableModule;
using ChestGame.Game.View;
using ChestGame.Game.Module.ScriptModule;
using ChestGame.Game.Models;
using System.Collections.Generic;

namespace ChestGame.Game.Controllers
{
    public class CardsShowController<T, U> : Controller<T, U> where T : CardsShowView where U : CardShowModel
    {
        public CardsShowController(T view, U model) : base(view, model) { }

        protected override void Init()
        {
            base.Init();
            _model.CardRandomizer = new CardRandomizerModule(_model.CardsData);
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
            await StartCardShowWithSprite(card, 1);
            _view.DestroyCurrentCardCombination();
            _model.Data.PlayerData.CardInventory.Add(card);

            var randomIndex = new System.Random().Next(0, 100);
            
            if(randomIndex < _model.CurrentChest.TokenBonusChanceInPercent)
            {
                await StartCardShow(_view.TokenBonusPref, 1);
                _model.Data.DepositToken(10);
                _model.Data.SystemData.PrizeFund -= 10;
                _model.Data.SystemData.ReloadPrizeFund();
            }
            else if (randomIndex < 50)
                await ShowCardWithRandomType();
            else
                await UniTask.Delay(3000);

            _view.DestroyCurrentCardCombination();
            _view.ShowCardEffect.SetActive(false);
        }

        public async UniTask StartDefaultBoxShow(bool isCrack)
        {
            _view.ShowCardEffect.SetActive(true);
            await UniTask.Delay(1000);

            await ShowCardWithRandomType();

            if (isCrack)
                EnableCracks();

            await UniTask.Delay(1000);

            _view.DestroyCurrentCardCombination();
            _view.ShowCardEffect.SetActive(false);
        }

        private async UniTask ShowCardWithRandomType()
        {
            var randomIndex = new System.Random().Next(0, 100);
            Debug.Log(randomIndex);

            if (randomIndex < _model.CurrentChest.WinChanceInProcent)
            {
                _model.Data.Statistic.WinNumber++;
                _view.WinCombinationAudio.Play();
                _model.Data.SystemData.PrizeFund -= (int)_model.CardRandomizer.CurrentWinCombination.Price;
                _model.Data.SystemData.ReloadPrizeFund();
                await StartCombinationShow(_model.CardRandomizer.CurrentWinCombination.Combination.AllCards);
                _model.Data.DepositToken((int)_model.CardRandomizer.CurrentWinCombination.Price);
            }
            else if (randomIndex < _model.CurrentChest.BonusChanceInProcaent)
            {
                _model.Data.Statistic.BonusNumber++;
                await StartCombinationShow(_model.CardRandomizer.CurrentBonusCombination.Combination.AllCards);
                EnableGoldenBorderInCards();
                _model.Data.PlayerData.BonusCombinationInventory.Add(_model.CardRandomizer.CurrentBonusCombination);
            }
            else
            {
                await StartCombinationShow(_model.CardRandomizer.GetRandomCombination());
            }
        }

        private async UniTask StartCombinationShow(List<CardInfo> combination)
        {
            for (int i = 0; i < 3; i++)
            {
                var card = combination[i];
                Debug.Log(card);
                await StartCardShowWithSprite(card, i);
            }
        }

        private async UniTask StartCardShow(GameObject cardPrefab, int positionIndex)
        {
            _view.InstantiateNewCard(cardPrefab);
            await StartCardsShowAnimationContinuity(positionIndex);
        }

        private async UniTask StartCardShowWithSprite(CardInfo card, int positionIndex)
        {
            _view.InstantiateNewCard(_model.CardsData.CardPref);
            _view.CurrentCard.GetComponent<CardView>().Preview.sprite = card.CardSprite;
            await StartCardsShowAnimationContinuity(positionIndex);
        }

        private void EnableCracks()
        {
            foreach (var card in _view.CurrentCardsCombination)
                if(card.GetComponent<CardView>().Cracks != null)
                    card.GetComponent<CardView>().Cracks.gameObject.SetActive(true);
        }

        public async UniTask StartCardsShowAnimationContinuity(int cardIndex)
        {
            await UIAnimations.SlideUpAnimation(_view.CurrentCard);
            await UniTask.Delay(500);

            var position = _view.CardPositions.transform.GetChild(cardIndex).gameObject;
            await UIAnimations.SlideToPointAnimation(position.transform.position, _view.CurrentCard.transform);
            await UniTask.Delay(1000);
        }
    }

}
