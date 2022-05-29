using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuApplication : MonoBehaviour, IApplication
{
    [SerializeField] private MenuView _view;
    [SerializeField] private MenuModel _model;
    internal MenuController<MenuView, MenuModel> _menuController;

    public MenuController<MenuView, MenuModel> InstantiateApplication()
    {
        _menuController = new MenuController<MenuView, MenuModel>(_view, _model);
        return _menuController;
    }
}
