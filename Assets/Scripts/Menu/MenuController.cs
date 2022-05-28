using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController
{
    private MenuView _view;
    private GameObject _currentScreen;


    public MenuController(MenuView view)
    {
        _view = view;
        _currentScreen = _view.chestInventoryScreen;
        _view.chestInventoryScreen.SetActive(true);
        view.cardInventoryButton.onClick.AddListener(delegate { SwitchScreens(_view.cardInventoryScreen); });
        view.chestInventoryButton.onClick.AddListener(delegate {SwitchScreens(_view.chestInventoryScreen); });
        view.shopButton.onClick.AddListener(delegate { SwitchScreens(_view.shopScreen); });
    }

    public void SwitchScreens(GameObject screen)
    {
        if(_currentScreen != null)
            _currentScreen.SetActive(false);
        screen.SetActive(true);
        _currentScreen = screen;
    }
}
