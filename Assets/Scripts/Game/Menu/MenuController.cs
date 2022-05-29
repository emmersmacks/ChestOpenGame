using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MenuController<T, U> : Controller<T, U> where T : MenuView where U : MenuModel
{
    public MenuController(T view, U model) : base(view, model) { }

    private bool isAnimationStart = false;

    protected override void Init()
    {
        SetDefaultScreen();

        _view.cardInventoryButton.onClick.AddListener(delegate { StartMenuSwitch(_view.cardInventoryScreen, _view.cardInventoryButton); });
        _view.chestInventoryButton.onClick.AddListener(delegate { StartMenuSwitch(_view.chestInventoryScreen, _view.chestInventoryButton); });
        _view.shopButton.onClick.AddListener(delegate { StartMenuSwitch(_view.shopScreen, _view.shopButton); });
    }

    private void SetDefaultScreen()
    {
        _model.currentScreen = _view.chestInventoryScreen;
        _view.chestInventoryScreen.SetActive(true);
        _model.currentButton = _view.chestInventoryButton.gameObject;
        ShowScreen(_model.currentScreen.GetComponent<CanvasGroup>());
        MarkButtonEnabled(_view.chestInventoryButton);
    }

    private void StartMenuSwitch(GameObject screen, Button button)
    {
        if(isAnimationStart == false)
        {
            MarkButtonDisable();
            MarkButtonEnabled(button);
            SwitchScreens(screen);
        }
    }

    public async UniTask SwitchScreens(GameObject screen)
    {
        await StartAlphaSwitchAnimation(_model.currentScreen.GetComponent<CanvasGroup>(), screen.GetComponent<CanvasGroup>());
        _model.currentScreen = screen;
    }

    private void MarkButtonEnabled(Button button)
    {
        _model.currentButton = button.gameObject;
        _model.currentButton.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        _model.currentButton.GetComponent<Image>().sprite = _model.buttonEnabled;
    }

    private void MarkButtonDisable()
    {
        _model.currentButton.transform.GetComponent<Image>().sprite = _model.buttonDisabled;
        _model.currentButton.transform.GetChild(0).GetComponent<Image>().color = Color.black;
    }

    private async UniTask StartAlphaSwitchAnimation(CanvasGroup currentGroup, CanvasGroup nextGroup)
    {
        isAnimationStart = true;
        await HideScreen(currentGroup);
        await ShowScreen(nextGroup);
        isAnimationStart = false;
    }

    private async UniTask HideScreen(CanvasGroup screen)
    {
        while (screen.alpha > 0)
        {
            screen.alpha -= 0.05f;
            await UniTask.Delay(10);
        }
    }

    private async UniTask ShowScreen(CanvasGroup screen)
    {
        while (screen.alpha < 1)
        {
            screen.alpha += 0.05f;
            await UniTask.Delay(10);
        }
    }
}
