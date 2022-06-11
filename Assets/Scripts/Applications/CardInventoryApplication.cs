using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventoryApplication : MonoBehaviour, IApplication
{
    [SerializeField] private InventoryView _view;
    [SerializeField] private CardInventoryModel _model;

    private CardInventoryController<InventoryView, CardInventoryModel> _cardInventoryController;

    public CardInventoryController<InventoryView, CardInventoryModel> InstanceApplication(PlayerDataController data)
    {
        _model.data = data;
        _cardInventoryController = new CardInventoryController<InventoryView, CardInventoryModel>(_view, _model);
        return _cardInventoryController;
    }
}
