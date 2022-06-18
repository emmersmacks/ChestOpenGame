using ChestGame.Data;
using ChestGame.Game.Controllers;
using ChestGame.Game.Models;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Applications
{
    public class ShopApplication : MonoBehaviour, IApplication
    {
        [SerializeField] private ShopView _view;
        [SerializeField] private ShopModel _model;

        private ShopController<ShopView, ShopModel> _shopController;

        public ShopController<ShopView, ShopModel> InstanceApplication(PlayerDataController data)
        {
            _model.Data = data;
            _shopController = new ShopController<ShopView, ShopModel>(_view, _model);
            return _shopController;
        }
    }
}

