using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ChestGame.Game.View;
using ChestGame.Game.Models;

namespace ChestGame.Game.Controllers
{
    public class MenuController<T, U> : Controller<T, U> where T : MenuView where U : MenuModel
    {
        public MenuController(T view, U model) : base(view, model) { }

        private bool _isAnimationStart = false;

        protected override void Init()
        {
            SetDefaultScreen();

            _view.CardInventoryButton.onClick.AddListener(delegate { StartMenuSwitch(_view.CardInventoryScreen, _view.CardInventoryButton); });
            _view.ChestInventoryButton.onClick.AddListener(delegate { StartMenuSwitch(_view.ChestInventoryScreen, _view.ChestInventoryButton); });
            _view.ShopButton.onClick.AddListener(delegate { StartMenuSwitch(_view.ShopScreen, _view.ShopButton); });
        }

        private void SetDefaultScreen()
        {
            _model.CurrentScreen = _view.ChestInventoryScreen;
            _view.ChestInventoryScreen.SetActive(true);
            _model.CurrentButton = _view.ChestInventoryButton.gameObject;
            ShowScreen(_model.CurrentScreen.GetComponent<CanvasGroup>());
            MarkButtonEnabled(_view.ChestInventoryButton);
        }

        private void StartMenuSwitch(GameObject screen, Button button)
        {
            if (_isAnimationStart == false)
            {
                _view.ButtonAudio.Play();
                MarkButtonDisable();
                MarkButtonEnabled(button);
                SwitchScreens(screen);
            }
        }

        public async UniTask SwitchScreens(GameObject screen)
        {
            await StartAlphaSwitchAnimation(_model.CurrentScreen.GetComponent<CanvasGroup>(), screen.GetComponent<CanvasGroup>());
            _model.CurrentScreen = screen;
        }

        private void MarkButtonEnabled(Button button)
        {
            _model.CurrentButton = button.gameObject;
            _model.CurrentButton.transform.GetChild(0).GetComponent<Image>().color = Color.white;
            _model.CurrentButton.GetComponent<Image>().sprite = _model.ButtonEnabled;
        }

        private void MarkButtonDisable()
        {
            _model.CurrentButton.transform.GetComponent<Image>().sprite = _model.ButtonDisabled;
            _model.CurrentButton.transform.GetChild(0).GetComponent<Image>().color = Color.black;
        }

        private async UniTask StartAlphaSwitchAnimation(CanvasGroup currentGroup, CanvasGroup nextGroup)
        {
            _isAnimationStart = true;
            await HideScreen(currentGroup);
            await ShowScreen(nextGroup);
            _isAnimationStart = false;
        }

        private async UniTask HideScreen(CanvasGroup screen)
        {
            while (screen.alpha > 0)
            {
                screen.alpha -= 0.08f;
                await UniTask.Delay(5);
            }
            screen.gameObject.SetActive(false);

        }

        private async UniTask ShowScreen(CanvasGroup screen)
        {
            screen.gameObject.SetActive(true);

            while (screen.alpha < 1)
            {
                screen.alpha += 0.08f;
                await UniTask.Delay(5);
            }
        }
    }
}

