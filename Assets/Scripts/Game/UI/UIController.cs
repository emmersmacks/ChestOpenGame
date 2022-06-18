using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using ChestGame.Game.Animations;
using ChestGame.Game.View;
using ChestGame.Data;
using ChestGame.Game.Models;

namespace ChestGame.Game.Controllers
{
    public class UIController
    {
        private PanelsView _panelsView;
        private UIView _view;

        public UIController(UIView view)
        {
            _panelsView = view.Panels;
            _view = view;
            _panelsView.WebSiteButton.onClick.AddListener(OpenWebSite);
            _view.KeyShopButton.onClick.AddListener(OpenShop);
            _view.ShopWindow.CloseButton.onClick.AddListener(CloseShop);
            _view.TrainingButton.onClick.AddListener(ShowTrainingWindow);
        }

        public void Init(PlayerDataController data)
        {
            UpdateTokenPanel(data);
            UpdateKeyPanel(data);
            UpdateMasterKeyPanel(data);
        }

        public void UpdateTokenPanel(PlayerDataController data)
        {
            _panelsView.TokenText.text = data.PlayerData.Token.ToString();
        }

        public void UpdateKeyPanel(PlayerDataController data)
        {
            _panelsView.KeyText.text = data.PlayerData.Keys.ToString();
        }

        public void UpdateMasterKeyPanel(PlayerDataController data)
        {
            _panelsView.MasterKeyText.text = data.PlayerData.MasterKeys.ToString();
        }

        private void OpenWebSite()
        {
            _view.ButtonAudio.Play();
            Application.OpenURL("https://getgems.io");
        }

        public void ShowTrainingWindow()
        {
            _view.ButtonAudio.Play();
            var view = _view.TrainingView;
            var model = new TrainingModel();
            var screen = new TrainingController<TrainingView, TrainingModel>(view, model);
            screen.OpenTrainingScreen();
        }

        private void OpenShop()
        {
            _view.ButtonAudio.Play();
            ShowScreenAnimation(_view.ShopWindow.Group);
        }

        private void CloseShop()
        {
            _view.ButtonAudio.Play();
            HideScreenAnimation(_view.ShopWindow.Group);
        }

        public async UniTask ArrowTrainingStart()
        {
            _view.TrainingArrow.SetActive(true);
            var upperCoord = new Vector3(_view.TrainingArrow.transform.position.x, _view.TrainingArrow.transform.position.y + 0.5f);
            var bottomCoord = new Vector3(_view.TrainingArrow.transform.position.x, _view.TrainingArrow.transform.position.y - 0.5f);
            await UIAnimations.SlideToPointAnimation(upperCoord, _view.TrainingArrow.transform);
            await UIAnimations.SlideToPointAnimation(bottomCoord, _view.TrainingArrow.transform);
            await UIAnimations.SlideToPointAnimation(upperCoord, _view.TrainingArrow.transform);
            await UIAnimations.SlideToPointAnimation(bottomCoord, _view.TrainingArrow.transform);
            StopArrowTraining();
        }

        public void StopArrowTraining()
        {
            _view.TrainingArrow.SetActive(false);
        }

        private async UniTask ShowScreenAnimation(CanvasGroup group)
        {
            _view.ShopWindow.gameObject.SetActive(true);
            await UIAnimations.SlideUpAnimation(group.gameObject.transform.GetChild(0).gameObject);
        }

        private async UniTask HideScreenAnimation(CanvasGroup group)
        {
            await UIAnimations.WindowSlideDownAnimation(group.gameObject.transform.GetChild(0).gameObject);
            _view.ShopWindow.gameObject.SetActive(false);
        }
    }
}

