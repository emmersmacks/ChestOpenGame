using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;
using ChestGame.Game.Animations;
using ChestGame.Game.View;
using ChestGame.Game.Models;

namespace ChestGame.Game.Controllers
{
    public class HoldersInventoryController<T, U> : Controller<T, U> where T : HoldersInventoryView where U : HoldersModel
    {
        public HoldersInventoryController(T view, U model) : base(view, model) { }

        private HoldersSlotView _currentSlot;

        protected override void Init()
        {
            FillInventorySlots();
            _view.CloseButton.onClick.AddListener(HideScreen);
            _model.Data.ReloadInventory += FillInventorySlots;
        }

        public void FillInventorySlots()
        {
            var count = 0;
            foreach (var item in _model.Data.PlayerData.BonusCombinationInventory)
            {

                var slot = _view.Grid.transform.GetChild(count);
                var slotView = slot.GetComponent<HoldersSlotView>();
                slotView.OpenButton.onClick.RemoveAllListeners();
                slotView.OpenButton.onClick.AddListener(delegate { StartCardReview(slotView); });
                slotView.CombinationView.FirstCardPreview.sprite = item.Combination.FirstCard.CardSprite;
                slotView.CombinationView.SecondCardPreview.sprite = item.Combination.SecondCard.CardSprite;
                slotView.CombinationView.ThirdCardPreview.sprite = item.Combination.ThirdCard.CardSprite;
                if (!slotView.TimerModule.TimerIsStart)
                    slotView.TimerModule.StartTimer();
                count++;
            }
        }

        private void HideScreen()
        {
            _view.CloseButton.gameObject.SetActive(false);
            _currentSlot.OpenButton.enabled = true;
            _view.CloseButton.enabled = false;
            _view.CardPositions.SetActive(false);
            _view.ScreenIsShow = false;
            _view.CardPresenterModule.DestroyCard(_model.CurrentCard);
        }

        private void StartCardReview(HoldersSlotView holderSlot)
        {
            _currentSlot = holderSlot;
            _currentSlot.OpenButton.enabled = false;
            _view.CloseButton.gameObject.SetActive(true);
            _view.CardPositions.SetActive(true);
            if (!_view.ScreenIsShow)
            {
                _view.ScreenIsShow = true;
                _model.CurrentCard = _view.CardPresenterModule.InstantiateNewCard(_model.CardPrefab);
                _model.CurrentCard.transform.GetChild(0).GetComponent<Image>().sprite = holderSlot.CombinationView.FirstCardPreview.sprite;
                _model.CurrentCard.transform.GetChild(1).GetComponent<Image>().sprite = holderSlot.CombinationView.SecondCardPreview.sprite;
                _model.CurrentCard.transform.GetChild(2).GetComponent<Image>().sprite = holderSlot.CombinationView.ThirdCardPreview.sprite;

                StartCardViewAnimation();
            }

        }

        private async UniTask StartCardViewAnimation()
        {
            await UIAnimations.SlideUpAnimation(_model.CurrentCard);
            for (int i = 0; i < 3; i++)
            {
                UIAnimations.SlideToPointAnimation(_view.CardPositions.transform.GetChild(i).gameObject.transform.position, _model.CurrentCard.transform.GetChild(i).gameObject.transform);
            }
            _view.CardPositions.SetActive(false);
        }
    }
}

