using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventoryApplication : MonoBehaviour, IApplication
{
    [SerializeField] private ChestInventoryView _view;
    [SerializeField] private ChestInventoryModel _model;

    private ChestInventoryController<ChestInventoryView, ChestInventoryModel> _chestInventoryController;

    public ChestInventoryController<ChestInventoryView, ChestInventoryModel> InstanceApplication(PlayerDataController data)
    {
        _model.data = data;
        _chestInventoryController = new ChestInventoryController<ChestInventoryView, ChestInventoryModel>(_view, _model);
        return _chestInventoryController;
    }
}
