using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeFundController<T, U> : Controller<T, U> where T : CombinationView where U : CardsDataBase
{
    public PrizeFundController(T view, U model) : base(view, model)
    {
    }

    protected override void Init()
    {
        UpdateCurrentPrize();
    }

    public void UpdateCurrentPrize()
    {
        var randomizer = new CardRandomizerModule(_model.allCards, _model.bonusCombinations);
        _view.FirstCardPreview.sprite = randomizer.GetRandomCard().cardSprite;
        _view.SecondCardPreview.sprite = randomizer.GetRandomCard().cardSprite;
        _view.ThirdCardPreview.sprite = randomizer.GetRandomCard().cardSprite;
        if (!_view.timerModule.TimerIsStart)
            _view.timerModule.StartTimer();
    }
}
