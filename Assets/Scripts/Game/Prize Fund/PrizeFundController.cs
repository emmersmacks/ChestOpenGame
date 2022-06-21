using ChestGame.Data;
using ChestGame.Game.Models;
using ChestGame.Game.Module.ScriptModule;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Controllers
{
    public class PrizeFundController<T, U> : Controller<T, U> where T : PrizeFundView where U : PrizeFundModel
    {
        public PrizeFundController(T view, U model) : base(view, model){}

        protected override void Init()
        {
            UpdateCurrentPrize();
            _model.Data.SystemData.ReloadPrizeFund += UpdateCurrentPrize;
        }

        public void UpdateCurrentPrize()
        {
            _view.PrizeFundCount.text = _model.Data.SystemData.PrizeFund.ToString();
            if (!_view.Timer.TimerIsStart)
                _view.Timer.StartTimer();
        }
    }
}

