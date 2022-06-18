using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using ChestGame.Game.Module.ScriptableModule;
using ChestGame.Game.View;
using ChestGame.Game.Models;

namespace ChestGame.Game.Controllers
{
    public class ShopController<T, U> : Controller<T, U> where T : ShopView where U : ShopModel
    {
        public ShopController(T view, U model) : base(view, model) { }

        private bool _canBuy = true;
        protected override void Init()
        {
            base.Init();
            FillAllSlots();
        }

        public void FillAllSlots()
        {
            var firstSlot = _view.Grid.transform.GetChild(0);
            var keySlotView = firstSlot.GetComponent<ShopSlotView>();
            FillSlot(keySlotView);
            keySlotView.BuyButton.onClick.RemoveAllListeners();
            keySlotView.BuyButton.onClick.AddListener(delegate { BuyKey(keySlotView.Chest); });
        }

        private void FillSlot(ShopSlotView view)
        {
            view.TextPrice.text = view.Chest.Price.ToString();
            view.Preview.sprite = view.Chest.ChestSprite;
        }

        private void BuyKey(ChestInfo itemInfo)
        {
            _view.ButtonSound.Play();
            if (_canBuy)
            {
                if (itemInfo.Price <= _model.Data.PlayerData.Token)
                {
                    _model.Data.Statistic.KeyCollectedNumber++;
                    Debug.Log("Buyed");
                    _model.Data.DebitingToken(itemInfo.Price);
                    _model.Data.DepositKey(1);
                    DestroyEffect();
                }
            }

        }

        private async UniTask DestroyEffect()
        {
            _canBuy = false;
            while (_view.Effect.alpha < 1)
            {
                _view.Effect.alpha += 0.05f;
                await UniTask.Delay(10);
            }
            while (_view.Effect.alpha > 0)
            {
                _view.Effect.alpha -= 0.05f;
                await UniTask.Delay(10);
            }
            _canBuy = true;
        }
    }
}

