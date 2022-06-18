using ChestGame.Game.Models;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Controllers
{
    public class TrainingController<T, U> : Controller<T, U> where T : TrainingView where U : TrainingModel
    {
        public TrainingController(T view, U model) : base(view, model) { }

        protected override void Init()
        {
            base.Init();
            _view.NextPageButton.onClick.RemoveAllListeners();
            _view.NextPageButton.onClick.AddListener(SwitchTrainingPage);

            _view.MainScreen.SetActive(true);
            _view.OpenChestScreen.SetActive(false);
        }

        public void OpenTrainingScreen()
        {
            _view.gameObject.SetActive(true);
        }

        public void CloseTrainingScreen()
        {
            _view.gameObject.SetActive(false);
        }

        private void SwitchTrainingPage()
        {
            CloseTrainingScreen();
        }
    }
}

