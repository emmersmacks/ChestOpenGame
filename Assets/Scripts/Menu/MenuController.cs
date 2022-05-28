using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController
{
    private MenuView _view;
    private GameObject _currentScreen;
    private GameObject _currentButton;


    public MenuController(MenuView view)
    {
        _view = view;
        _currentScreen = _view.chestInventoryScreen;
        _view.chestInventoryScreen.SetActive(true);
        _currentButton = _view.chestInventoryButton.gameObject;
        _currentButton.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        _currentButton.GetComponent<Image>().sprite = _view.enableSprite;
        view.cardInventoryButton.onClick.AddListener(delegate { SwitchScreens(_view.cardInventoryScreen, _view.cardInventoryButton); });
        view.chestInventoryButton.onClick.AddListener(delegate {SwitchScreens(_view.chestInventoryScreen, _view.chestInventoryButton); });
        view.shopButton.onClick.AddListener(delegate { SwitchScreens(_view.shopScreen, _view.shopButton); });
    }

    public void SwitchScreens(GameObject screen, Button button)
    {
        if(_currentButton != null)
        {
            _currentButton.transform.GetComponent<Image>().sprite = _view.disableSprite;
            _currentButton.transform.GetChild(0).GetComponent<Image>().color = Color.black;
        }
        _currentButton = button.gameObject;
        _currentButton.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        button.gameObject.GetComponent<Image>().sprite = _view.enableSprite;
        if(_currentScreen != null)
            _currentScreen.SetActive(false);
        screen.SetActive(true);
        _currentScreen = screen;
    }
}
