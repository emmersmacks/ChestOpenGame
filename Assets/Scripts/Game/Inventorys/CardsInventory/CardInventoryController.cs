using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using ChestGame.Game.Animations;
using ChestGame.Game.View;
using ChestGame.Game.Models;

namespace ChestGame.Game.Controllers
{
    public class CardInventoryController<T, U> : Controller<T, U> where T : CardsInventoryView where U : CardInventoryModel
    {
        public CardInventoryController(T view, U model) : base(view, model) { }

        private InventoryCardsSlotView _currentSlot;

        protected override void Init()
        {
            _model.Data.SystemData.ReloadInventory += FillInventorySlots;
            _view.ClosePresenterButton.onClick.AddListener(HideScreen);
            FillInventorySlots();
        }

        public void FillInventorySlots()
        {
            var count = 0;
            foreach (var item in _model.Data.PlayerData.CardInventory)
            {
                var slot = _view.Grid.transform.GetChild(count);
                var slotView = slot.GetComponent<InventoryCardsSlotView>();
                slotView.Preview.sprite = item.CardSprite;
                slotView.Card = item;
                slotView.Button.onClick.RemoveAllListeners();
                slotView.Button.onClick.AddListener(delegate { StartCardViewAnimation(slotView); });
                count++;
            }
        }

        private async UniTask StartCardViewAnimation(InventoryCardsSlotView viewSlot)
        {
            _view.ClosePresenterButton.gameObject.SetActive(true);
            _currentSlot = viewSlot;
            _view.ClosePresenterButton.enabled = true;
            viewSlot.Button.enabled = false;
            _view.ScreenIsShow = true;
            _model.CurrentCard = _view.CardPresenterModule.InstantiateNewCard(_model.CardPrefab);
            _model.CurrentCard.GetComponent<CardView>().Preview.sprite = viewSlot.Preview.sprite;
            await UIAnimations.SlideUpAnimation(_model.CurrentCard);
            for (int i = 0; i < 3; i++)
            {
                UIAnimations.SlideToPointAnimation(_view.CardPositions.transform.GetChild(1).gameObject.transform.position, _model.CurrentCard.transform.GetChild(i).gameObject.transform);
            }
        }

        private void HideScreen()
        {
            _view.ClosePresenterButton.gameObject.SetActive(false);
            _currentSlot.Button.enabled = true;
            _view.CardPositions.SetActive(false);
            _view.ScreenIsShow = false;
            _view.CardPresenterModule.DestroyCard(_model.CurrentCard);
            _view.ClosePresenterButton.enabled = false;

        }
    }
}

