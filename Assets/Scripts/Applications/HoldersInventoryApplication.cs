using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldersInventoryApplication : MonoBehaviour, IApplication
{
    [SerializeField] private InventoryView _view;
    [SerializeField] private HoldersModel _model;

    private HoldersController<InventoryView, HoldersModel> _holdersInventoryController;

    public HoldersController<InventoryView, HoldersModel> InstanceApplication(PlayerDataController data)
    {
        _model.data = data;
        _holdersInventoryController = new HoldersController<InventoryView, HoldersModel>(_view, _model);
        return _holdersInventoryController;
    }
}
