using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpenApplication : MonoBehaviour, IApplication
{
    [SerializeField] private ChestOpenView _view;
    [SerializeField] private ChestOpenModel _model;

    private ChestOpenController<ChestOpenView, ChestOpenModel> _chestOpenController;

    public ChestOpenController<ChestOpenView, ChestOpenModel> InstanceApplication(PlayerDataController data, CardController cardController)
    {
        _model.cardController = cardController;
        _model.data = data;
        _chestOpenController = new ChestOpenController<ChestOpenView, ChestOpenModel>(_view, _model);
        return _chestOpenController;
    }
}
