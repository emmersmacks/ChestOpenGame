using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopApplication : MonoBehaviour, IApplication
{
    [SerializeField] private ShopView _view;
    [SerializeField] private ShopModel _model;

    private ShopController<ShopView, ShopModel> _shopController;

    public ShopController<ShopView, ShopModel> InstanceApplication(PlayerDataController data)
    {
        _model.data = data;
        _shopController = new ShopController<ShopView, ShopModel>(_view, _model);
        return _shopController;
    }
}
