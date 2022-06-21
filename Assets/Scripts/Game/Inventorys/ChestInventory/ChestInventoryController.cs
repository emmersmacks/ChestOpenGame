using ChestGame.Data;
using ChestGame.Game.Models;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Controllers
{
    public class ChestInventoryController<T, U> : Controller<T, U> where T : ChestInventoryView where U : ChestInventoryModel
    {
        public ChestInventoryController(T view, U model) : base(view, model) { }

        public ChestOpenController<ChestOpenView, ChestOpenModel> ChestOpenController { get; set; }

        protected override void Init()
        {
            base.Init();
            _model.Data.Statistic.ChangeStatistic += FillStatisticScreen;
            _model.Data.SystemData.ReloadInventory += FillInventorySlots;
            var prizeModel = new PrizeFundModel();
            prizeModel.Data = _model.Data;
            var prizeFund = new PrizeFundController<PrizeFundView, PrizeFundModel>(_view.CombinationView, prizeModel);
            FillInventorySlots();
            FillStatisticScreen();
            FillPrizePanel();
        }

        public void FillInventorySlots()
        {
            Clearinventory();
            var count = 0;
            foreach (var item in _model.Data.PlayerData.ChestInventory)
            {
                var slot = _view.Grid.transform.GetChild(count);
                var slotView = slot.GetComponent<InventoryChestSlotView>();
                slotView.Preview.sprite = item.ChestSprite;
                slotView.Chest = item;
                slotView.Button.onClick.AddListener(delegate { StartOpenScript(slotView); });
                count++;
            }
        }

        public void Clearinventory()
        {
            for (int i = 0; i < _view.Grid.transform.childCount; i++)
            {
                var currentSlot = _view.Grid.transform.GetChild(i).GetComponent<InventoryChestSlotView>();
                currentSlot.Preview.sprite = _view.SlotsBackground;
                currentSlot.Chest = null;
                currentSlot.Button.onClick.RemoveAllListeners();
            }
        }

        private void StartOpenScript(InventoryChestSlotView slot)
        {
            var model = Resources.Load<ChestOpenModel>("ChestOpenModel");
            model.SlotView = slot;
            model.CurrentChest = slot.Chest;
            model.Data = _model.Data;
            model.Inventory = _view.Grid;

            ChestOpenController = new ChestOpenController<ChestOpenView, ChestOpenModel>(_view.ChestOpenView, model);

        }

        private void FillStatisticScreen()
        {
            _view.StatisticView.SetTextInField(_view.StatisticView.WinCount, "Number of winning combinations: " + _model.Data.Statistic.WinNumber.ToString());
            _view.StatisticView.SetTextInField(_view.StatisticView.BonusCombinationsCount, "Number of bonus combinations: " + _model.Data.Statistic.BonusNumber.ToString());
            _view.StatisticView.SetTextInField(_view.StatisticView.TokenCollectedCount, "Token collected: " + _model.Data.Statistic.TokenCollectedNumber.ToString());
            _view.StatisticView.SetTextInField(_view.StatisticView.KeyCollectedCount, "Key collected: " + _model.Data.Statistic.KeyCollectedNumber.ToString());
            _view.StatisticView.SetTextInField(_view.StatisticView.OpenChestCount, "Number of open chests: " + _model.Data.Statistic.ChestOpenNumber.ToString());
        }

        private void FillPrizePanel()
        {
            var bonusPanelModel = Resources.Load<CardsDataBase>("CardsDataBase");
            var bonusPanelView = _view.BonusCombinationView;
            var bonusCombinationController = new BonusCombinationsPanelController<BonusCombinationsView, CardsDataBase>(bonusPanelView, bonusPanelModel);
        }
    }
}

