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
            var randomizer = new CardRandomizerModule(_model);
            for (int i = 0; i < 10; i++)
            {
                var cards = randomizer.GetBonusCombination();
                _view.AddCardCombination(_view.ToncoinPanel5, cards);
            }
            for (int i = 0; i < 5; i++)
            {
                var cards = randomizer.GetBonusCombination();
                _view.AddCardCombination(_view.ToncoinPanel10, cards);
            }
            for (int i = 0; i < 2; i++)
            {
                var cards = randomizer.GetBonusCombination();
                _view.AddCardCombination(_view.ToncoinPanel50, cards);
            }
        }
    }
}



