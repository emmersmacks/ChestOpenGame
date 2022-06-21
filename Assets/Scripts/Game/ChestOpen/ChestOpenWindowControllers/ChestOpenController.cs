using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using System;
using ChestGame.Game.Animations;
using ChestGame.Game.View;
using ChestGame.Game.Models;
using ChestGame.Game.Module.ScriptableModule;
using ChestGame.Data;

namespace ChestGame.Game.Controllers
{
    public class ChestOpenController<T, U> : Controller<T, U> where T : ChestOpenView where U : ChestOpenModel
    {

        private bool _buttonAnimation = false;
        internal InventoryChestSlotView ChestOpenSlotView;

        public ChestOpenController(T view, U model) : base(view, model) { }

        protected override void Init()
        {
            base.Init();
            ShowOpenScreen();
        }

        public async UniTask ShowOpenScreen()
        {
            FillOpenScreenData();
            ChestOpenSlotView = _view.InstantiateSlotCopy(_model.SlotView);
            ChestOpenSlotView.Preview.sprite = _model.CurrentChest.ChestSprite;
            ChestOpenSlotView.transform.SetSiblingIndex(0);
            _model.SlotView.Button.enabled = false;
            ChestOpenSlotView.DefaultPosition = _model.SlotView.transform.position;
            _model.DefaultButtonPosition = _view.Buttons.transform.position;
            _view.gameObject.SetActive(true);
            UIAnimations.SlideToPointAnimation(Vector3.zero, ChestOpenSlotView.transform);
            UIAnimations.FadeColorToDark(_view.GetComponent<Image>());
            _view.OpenChestAudio.Play();
            await UIAnimations.ScaleZoom(ChestOpenSlotView.transform);
            UIAnimations.SlideToPointAnimation(new Vector3(0, _view.Buttons.transform.position.y, 0), _view.Buttons.transform);
            await UIAnimations.SlideToPointAnimation(ChestOpenSlotView.ZoomPozitionPreview.position, ChestOpenSlotView.Preview.transform);
            _view.CloseButton.gameObject.SetActive(true);
        }

        private void UpgradeButtonCheckSwitch()
        {
            if (_model.CurrentChest.ChestName != _model.DefaultChest.ChestName || CheckChestContain(_model.UpgradeChest))
                _view.UpgradeButton.gameObject.SetActive(false);
            else
                _view.UpgradeButton.gameObject.SetActive(true);

            if (_model.CurrentChest.ChestName != _model.DefaultChest.ChestName)
                _view.HackButton.gameObject.SetActive(false);
            else
                _view.HackButton.gameObject.SetActive(true);
        }

        public async UniTask CloseOpenScreen()
        {
            _view.ButtonAudio.Play();
            _view.CloseButton.gameObject.SetActive(false);

            UIAnimations.SlideToPointAnimation(ChestOpenSlotView.DefaultPosition, ChestOpenSlotView.transform);
            UIAnimations.FadeColorToWhite(_view.GetComponent<Image>());
            UIAnimations.SlideToPointAnimation(new Vector3(_model.DefaultButtonPosition.x, _model.DefaultButtonPosition.y, 0), _view.Buttons.transform);
            await UIAnimations.ScaleMinimaze(ChestOpenSlotView.transform);
            await UIAnimations.SlideToPointAnimation(ChestOpenSlotView.DefaultPositionPreview.position, ChestOpenSlotView.Preview.transform);

            _model.Data.SystemData.ReloadInventory();

            _view.gameObject.SetActive(false);
            _model.SlotView.Button.enabled = true;
            _view.DestroySlotCopy(ChestOpenSlotView);
        }

        public async UniTask MinimizeOpenScreen()
        {
            _view.CloseButton.gameObject.SetActive(false);

            UIAnimations.SlideToPointAnimation(ChestOpenSlotView.DefaultPosition, ChestOpenSlotView.transform);
            UIAnimations.SlideToPointAnimation(new Vector3(_model.DefaultButtonPosition.x, 0, 0), _view.Buttons.transform);
            await UIAnimations.ScaleMinimaze(ChestOpenSlotView.transform);
            await UIAnimations.SlideToPointAnimation(ChestOpenSlotView.DefaultPositionPreview.position, ChestOpenSlotView.Preview.transform);
            ChestOpenSlotView.gameObject.SetActive(false);
            _model.SlotView.Button.enabled = true;
        }

        public void FillOpenScreenData()
        {
            _view.CloseButton.onClick.RemoveAllListeners();
            _view.OpenButton.onClick.RemoveAllListeners();
            _view.HackButton.onClick.RemoveAllListeners();
            _view.UpgradeButton.onClick.RemoveAllListeners();

            _view.Preview.sprite = _model.CurrentChest.ChestSprite;
            _view.CloseButton.onClick.AddListener(delegate { CloseOpenScreen(); });
            _view.OpenButton.onClick.AddListener(delegate { OpenStart(false); });
            _view.HackButton.onClick.AddListener(delegate { OpenStart(true); });
            _view.UpgradeButton.onClick.AddListener(delegate { ChestUpgrade(); });
            UpgradeButtonCheckSwitch();
        }

        private async UniTask OpenStart(bool isHack)
        {
            _view.ButtonAudio.Play();
            if (!isHack)
            {
                if (_model.Data.PlayerData.Keys > 0)
                {
                    _model.Data.DebitingKey(1);
                    await ShowCards(false);
                }
                else if (!_buttonAnimation)
                {
                    _buttonAnimation = true;
                    await UIAnimations.TransformShakeOnX(_view.OpenButton.transform);
                    _buttonAnimation = false;
                }
            }
            else
            {
                if (_model.Data.PlayerData.MasterKeys > 0)
                {
                    _model.Data.DebitingMasterKey(1);
                    await ShowCards(true);
                }
                else if (!_buttonAnimation)
                {
                    _buttonAnimation = true;
                    await UIAnimations.TransformShakeOnX(_view.HackButton.transform);
                    _buttonAnimation = false;
                }
            }
        }

        private async UniTask ShowCards(bool isCrack)
        {
            _view.CardShowView.gameObject.SetActive(true);
            var cardShowController = GetCardShowController();

            _view.OpenChestEffect.SetActive(true);
            await MinimizeOpenScreen();
            _model.Data.Statistic.ChestOpenNumber++;

            if (_model.CurrentChest.ChestName == _model.UpgradeChest.ChestName)
            {
                _view.MisteryBoxAudio.Play();
                await cardShowController.StartMisteryBoxShow();
                DeleteMisteryBoxInInventory();
            }
            else
            {
                await cardShowController.StartDefaultBoxShow(isCrack);
            }

            _model.Data.SystemData.ReloadInventory();
            await CloseOpenScreen();
            _view.OpenChestEffect.SetActive(false);
            _view.CardShowView.gameObject.SetActive(false);
        }

        public void DeleteMisteryBoxInInventory()
        {
            for (var i = 0; i < _model.Data.PlayerData.ChestInventory.Count; i++)
            {
                if (_model.Data.PlayerData.ChestInventory[i].ChestName == _model.CurrentChest.ChestName)
                {
                    _model.Data.PlayerData.ChestInventory.RemoveAt(i);
                    break;
                }
            }
        }

        public async UniTask ChestUpgrade()
        {
            _view.ButtonAudio.Play();
            if (!CheckChestContain(_model.UpgradeChest) && _model.Data.PlayerData.Token >= 10)
            {
                _model.Data.DebitingToken(10);
                _model.Data.PlayerData.ChestInventory.Add(_model.UpgradeChest);
                _view.UpgradeButton.gameObject.SetActive(false);
                CloseOpenScreen();
                _model.Data.SystemData.ReloadInventory();
            }
            else
            {
                await UIAnimations.TransformShakeOnX(_view.UpgradeButton.transform);
            }
        }

        private bool CheckChestContain(ChestInfo chest)
        {
            foreach (var inventoryChest in _model.Data.PlayerData.ChestInventory)
            {
                if (inventoryChest.ChestName == chest.ChestName)
                    return true;
            }
            return false;
        }

        private CardsShowController<CardsShowView, CardShowModel> GetCardShowController()
        {
            var cardShowModel = new CardShowModel();
            cardShowModel.CardsData = Resources.Load<CardsDataBase>("CardsDataBase");
            cardShowModel.Data = _model.Data;
            cardShowModel.CurrentChest = _model.CurrentChest;
            var cardShowView = _view.CardShowView;
            var controller = new CardsShowController<CardsShowView, CardShowModel>(cardShowView, cardShowModel);
            return controller;
        }
    }
}
