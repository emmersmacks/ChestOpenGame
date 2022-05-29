using UnityEngine;
using UnityEngine.UI;

public class MenuController<T, U> : Controller<T, U> where T : MenuView where U : MenuModel
{
    public MenuController(T view, U model) : base(view, model) { }

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
        MarkButtonEnabled(_view.chestInventoryButton);
    }

    private void StartMenuSwitch(GameObject screen, Button button)
    {
        MarkButtonDisable();
        MarkButtonEnabled(button);
        SwitchScreens(screen);
    }

    public void SwitchScreens(GameObject screen)
    {
        if (_model.currentScreen != null)
            _model.currentScreen.SetActive(false);
        screen.SetActive(true);
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
}
