using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldersInventoryApplication : MonoBehaviour, IApplication
{
    [SerializeField] private HoldersInventoryView _view;
    [SerializeField] private HoldersModel _model;

    private HoldersInventoryController<HoldersInventoryView, HoldersModel> _holdersInventoryController;

    public HoldersInventoryController<HoldersInventoryView, HoldersModel> InstanceApplication(PlayerDataController data)
    {
        _model.data = data;
        _holdersInventoryController = new HoldersInventoryController<HoldersInventoryView, HoldersModel>(_view, _model);
        return _holdersInventoryController;
    }
}
