using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class UIController
{
    private PanelsView _panelsView;
    private UIView _view;

   

    public UIController(UIView view)
    {
        _panelsView = view.panels;
        _view = view;
        _panelsView.webSiteButton.onClick.AddListener(OpenWebSite);
        _view.keyShopButton.onClick.AddListener(OpenShop);
        _view.shopWindow.closeButton.onClick.AddListener(CloseShop);
        _view.trainingButton.onClick.AddListener(ShowTrainingWindow);
    }

    public void Init(PlayerDataController data)
    {
        UpdateTokenPanel(data);
        UpdateKeyPanel(data);
        UpdateMasterKeyPanel(data);
    }

    public void UpdateTokenPanel(PlayerDataController data)
    {
        _panelsView.tokenText.text = data.Data.Token.ToString();
    }

    public void UpdateKeyPanel(PlayerDataController data)
    {
        _panelsView.keyText.text = data.Data.Keys.ToString();
    }

    public void UpdateMasterKeyPanel(PlayerDataController data)
    {
        _panelsView.masterKeyText.text = data.Data.MasterKeys.ToString();
    }

    private void OpenWebSite()
    {
        _view.buttonAudio.Play();
        Application.OpenURL("https://getgems.io");
    }

    public void ShowTrainingWindow()
    {
        _view.buttonAudio.Play();
        var view = _view.trainingView;
        var model = new TrainingModel();
        var screen = new TrainingController<TrainingView, TrainingModel>(view, model);
        screen.OpenTrainingScreen();
    }

    private void OpenShop()
    {
        _view.buttonAudio.Play();
        ShowScreenAnimation(_view.shopWindow.group); 
    }

    private void CloseShop()
    {
        _view.buttonAudio.Play();
        HideScreenAnimation(_view.shopWindow.group);
    }

    public async UniTask ArrowTrainingStart()
    {
        _view.trainingArrow.SetActive(true);
        var upperCoord = new Vector3(_view.trainingArrow.transform.position.x, _view.trainingArrow.transform.position.y + 0.5f);
        var bottomCoord = new Vector3(_view.trainingArrow.transform.position.x , _view.trainingArrow.transform.position.y - 0.5f);
        await UIAnimations.SlideToPointAnimation(upperCoord, _view.trainingArrow.transform);
        await UIAnimations.SlideToPointAnimation(bottomCoord, _view.trainingArrow.transform);
        await UIAnimations.SlideToPointAnimation(upperCoord, _view.trainingArrow.transform);
        await UIAnimations.SlideToPointAnimation(bottomCoord, _view.trainingArrow.transform);
        StopArrowTraining();
    }

    public void StopArrowTraining()
    {
        _view.trainingArrow.SetActive(false);
    }

    private async UniTask ShowScreenAnimation(CanvasGroup group)
    {
        _view.shopWindow.gameObject.SetActive(true);
        await UIAnimations.SlideUpAnimation(group.gameObject.transform.GetChild(0).gameObject);
    }

    private async UniTask HideScreenAnimation(CanvasGroup group)
    {
        await UIAnimations.WindowSlideDownAnimation(group.gameObject.transform.GetChild(0).gameObject);
        _view.shopWindow.gameObject.SetActive(false);
    }
}
