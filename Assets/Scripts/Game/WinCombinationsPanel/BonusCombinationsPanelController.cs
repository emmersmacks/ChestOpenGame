using ChestGame.Data;
using ChestGame.Game.Module.ScriptModule;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

namespace ChestGame.Game.Controllers
{
    public class BonusCombinationsPanelController<T, U> : Controller<T, U> where T : BonusCombinationsView where U : CardsDataBase
    {
        public BonusCombinationsPanelController(T view, U model) : base(view, model) { }

        protected override void Init()
        {
            base.Init();
            FillBonusCombinationsPanels();
        }

        private void FillBonusCombinationsPanels()
        {
            foreach(var combination in _model.WinCombinations)
            {
                if (combination.Price == PriceType.coin5)
                    _view.AddCardCombination(_view.ToncoinPanel5, combination);
                else if(combination.Price == PriceType.coin10)
                    _view.AddCardCombination(_view.ToncoinPanel10, combination);
                else
                    _view.AddCardCombination(_view.ToncoinPanel50, combination);
            }
        }
    }
}



