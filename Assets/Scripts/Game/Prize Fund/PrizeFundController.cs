using ChestGame.Data;
using ChestGame.Game.Module.ScriptModule;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Controllers
{
    public class PrizeFundController<T, U> : Controller<T, U> where T : CombinationView where U : CardsDataBase
    {
        public PrizeFundController(T view, U model) : base(view, model){}

        protected override void Init()
        {
            UpdateCurrentPrize();
        }

        public void UpdateCurrentPrize()
        {
            var randomizer = new CardRandomizerModule(_model);
            _view.FirstCardPreview.sprite = randomizer.GetRandomCard().CardSprite;
            _view.SecondCardPreview.sprite = randomizer.GetRandomCard().CardSprite;
            _view.ThirdCardPreview.sprite = randomizer.GetRandomCard().CardSprite;
            if (!_view.TimerModule.TimerIsStart)
                _view.TimerModule.StartTimer();
        }
    }
}

