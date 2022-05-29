using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventoryApplication : MonoBehaviour, IApplication
{
    [SerializeField] private InventoryView _view;
    [SerializeField] private ChestInventoryModel _model;

    private ChestInventoryController<InventoryView, ChestInventoryModel> _chestInventoryController;

    public ChestInventoryController<InventoryView, ChestInventoryModel> InstanceApplication(PlayerDataController data, ChestOpenController<ChestOpenView, ChestOpenModel> chestOpenController)
    {
        _model.data = data;
        _model.chestOpenController = chestOpenController;
        _chestInventoryController = new ChestInventoryController<InventoryView, ChestInventoryModel>(_view, _model);
        return _chestInventoryController;
    }
}
