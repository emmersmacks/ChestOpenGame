using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingController<T, U> : Controller<T, U> where T : TrainingView where U : TrainingModel
{
    public TrainingController(T view, U model) : base(view, model){}

    protected override void Init()
    {
        base.Init();
        _view.nextPageButton.onClick.RemoveAllListeners();
        _view.nextPageButton.onClick.AddListener(SwitchTrainingPage);

        _view.mainScreen.SetActive(true);
        _view.openChestScreen.SetActive(false);
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
        //if(_view.mainScreen.activeInHierarchy)
        //{
        //    _view.mainScreen.SetActive(false);
        //    _view.openChestScreen.SetActive(true);
        //}
        //else
        //{
        //    _view.openChestScreen.SetActive(false);
        //    CloseTrainingScreen();
        //}
    }
}
