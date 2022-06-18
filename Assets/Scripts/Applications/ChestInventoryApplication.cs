using ChestGame.Data;
using ChestGame.Game.Controllers;
using ChestGame.Game.Models;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Applications
{
    public class ChestInventoryApplication : MonoBehaviour, IApplication
    {
        [SerializeField] private ChestInventoryView _view;
        [SerializeField] private ChestInventoryModel _model;

        private ChestInventoryController<ChestInventoryView, ChestInventoryModel> _chestInventoryController;

        public ChestInventoryController<ChestInventoryView, ChestInventoryModel> InstanceApplication(PlayerDataController data)
        {
            _model.Data = data;
            _chestInventoryController = new ChestInventoryController<ChestInventoryView, ChestInventoryModel>(_view, _model);
            return _chestInventoryController;
        }
    }
}

