using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventoryController<T, U> : Controller<T, U> where T : ChestInventoryView where U : ChestInventoryModel
{
    public ChestInventoryController(T view, U model) : base(view, model){}

    public ChestOpenController<ChestOpenView, ChestOpenModel> chestOpenController { get; set; }

    protected override void Init()
    {
        base.Init();
        _model.data.Statistic.ChangeStatistic += FillStatisticScreen;
        _model.data.reloadInventory += FillInventorySlots;
        var prizeModel = Resources.Load<CardsDataBase>("CardsDataBase");
        var prizeFund = new PrizeFundController<CombinationView, CardsDataBase>(_view.combinationView, prizeModel);
        FillInventorySlots();
        FillStatisticScreen();
        FillPrizePanel();
    }

    public void FillInventorySlots()
    {
        Clearinventory();
        var count = 0;
        foreach(var item in _model.data.Data.ChestInventory)
        {
            var slot = _view.grid.transform.GetChild(count);
            var slotView = slot.GetComponent<InventoryChestSlotView>();
            slotView.preview.sprite = item.chestSprite;
            slotView.chest = item;
            slotView.button.onClick.AddListener(delegate { StartOpenScript(slotView); });
            count++;
        }
    }

    public void Clearinventory()
    {
        for(int i = 0; i < _view.grid.transform.childCount; i++)
        {
            var currentSlot = _view.grid.transform.GetChild(i).GetComponent<InventoryChestSlotView>();
            currentSlot.preview.sprite = _view.slotsBackground;
            currentSlot.chest = null;
            currentSlot.button.onClick.RemoveAllListeners();
        }
    }

    private void StartOpenScript(InventoryChestSlotView slot)
    {
        var model = Resources.Load<ChestOpenModel>("ChestOpenModel");
        model.slotView = slot;
        model.currentChest = slot.chest;
        model.data = _model.data;
        model.inventory = _view.grid;

        chestOpenController = new ChestOpenController<ChestOpenView, ChestOpenModel>(_view.chestOpenView, model);
        
    }

    private void FillStatisticScreen()
    {
        _view.statisticView.SetTextInField(_view.statisticView.winCount, "Number of winning combinations: " + _model.data.Statistic.WinNumber.ToString());
        _view.statisticView.SetTextInField(_view.statisticView.bonusCombinationsCount, "Number of bonus combinations: " + _model.data.Statistic.BonusNumber.ToString());
        _view.statisticView.SetTextInField(_view.statisticView.tokenCollectedCount, "Token collected: " + _model.data.Statistic.TokenCollectedNumber.ToString());
        _view.statisticView.SetTextInField(_view.statisticView.keyCollectedCount, "Key collected: " + _model.data.Statistic.KeyCollectedNumber.ToString());
        _view.statisticView.SetTextInField(_view.statisticView.openChestCount, "Number of open chests: " + _model.data.Statistic.ChestOpenNumber.ToString());
    }

    private void FillPrizePanel()
    {
        var bonusPanelModel = Resources.Load<CardsDataBase>("CardsDataBase");
        var bonusPanelView = _view.bonusCombinationView;
        var bonusCombinationController = new BonusCombinationsPanelController<BonusCombinationsView, CardsDataBase>(bonusPanelView, bonusPanelModel);
    }
}
