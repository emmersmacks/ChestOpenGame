using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using System;

public class ChestOpenController<T, U> : Controller<T, U> where T : ChestOpenView where U : ChestOpenModel
{
    
    bool buttonAnimation = false;

    public ChestOpenController(T view, U model) : base(view, model){}

    protected override void Init()
    {
        base.Init();
        ShowOpenScreen();
    }

    public async UniTask ShowOpenScreen()
    {
        FillOpenScreenData();
        _model.slotView.button.enabled = false;

        _model.slotView.defaultPosition = _model.slotView.transform.position;
        _model.defaultButtonPosition = _view.buttons.transform.position;
        _model.slotView.transform.parent = _view.transform;
        _view.gameObject.SetActive(true);
        _model.slotView.transform.SetSiblingIndex(0);
        UIAnimations.SlideToPointAnimation(Vector3.zero, _model.slotView.transform);
        UIAnimations.FadeColorToDark(_view.GetComponent<Image>());
        _view.openChestAudio.Play();
        await UIAnimations.ScaleZoom(_model.slotView.transform);
        UIAnimations.SlideToPointAnimation(new Vector3(0, _view.buttons.transform.position.y, 0), _view.buttons.transform);
        await UIAnimations.SlideToPointAnimation(_model.slotView.zoomPozitionPreview.position, _model.slotView.preview.transform);
        _view.closeButton.gameObject.SetActive(true);
    }

    private void UpgradeButtonCheckSwitch()
    {
        if (_model.currentChest.chestName != _model.defaultChest.chestName || CheckChestContain(_model.upgradeChest))
            _view.upgradeButton.gameObject.SetActive(false);
        else
            _view.upgradeButton.gameObject.SetActive(true);
    }

    public async UniTask CloseOpenScreen()
    {
        _view.buttonAudio.Play();
        _view.closeButton.gameObject.SetActive(false);
        
        UIAnimations.SlideToPointAnimation(_model.slotView.defaultPosition, _model.slotView.transform);
        UIAnimations.FadeColorToWhite(_view.GetComponent<Image>());
        UIAnimations.SlideToPointAnimation(new Vector3(_model.defaultButtonPosition.x, 0, 0), _view.buttons.transform);
        await UIAnimations.ScaleMinimaze(_model.slotView.transform);
        await UIAnimations.SlideToPointAnimation(_model.slotView.defaultPositionPreview.position, _model.slotView.preview.transform);

        _model.slotView.transform.parent = _model.inventory.transform;
        _model.slotView.transform.SetSiblingIndex(0);
        _model.data.reloadInventory();

        _view.gameObject.SetActive(false);
        _model.slotView.button.enabled = true;
    }

    public async UniTask MinimizeOpenScreen()
    {
        _view.closeButton.gameObject.SetActive(false);

        UIAnimations.SlideToPointAnimation(_model.slotView.defaultPosition, _model.slotView.transform);
        UIAnimations.SlideToPointAnimation(new Vector3(_model.defaultButtonPosition.x, 0, 0), _view.buttons.transform);
        await UIAnimations.ScaleMinimaze(_model.slotView.transform);
        await UIAnimations.SlideToPointAnimation(_model.slotView.defaultPositionPreview.position, _model.slotView.preview.transform);

        _model.slotView.transform.parent = _model.inventory.transform;
        _model.slotView.transform.SetSiblingIndex(0);

        _model.slotView.button.enabled = true;
    }

    public void FillOpenScreenData()
    {
        _view.closeButton.onClick.RemoveAllListeners();
        _view.openButton.onClick.RemoveAllListeners();
        _view.hackButton.onClick.RemoveAllListeners();
        _view.upgradeButton.onClick.RemoveAllListeners();

        _view.preview.sprite = _model.currentChest.chestSprite;
        _view.closeButton.onClick.AddListener(delegate { CloseOpenScreen(); });
        _view.openButton.onClick.AddListener(delegate { OpenStart(false); });
        _view.hackButton.onClick.AddListener(delegate { OpenStart(true); });
        _view.upgradeButton.onClick.AddListener(delegate { ChestUpgrade(); });
        UpgradeButtonCheckSwitch();
    }

    private async UniTask OpenStart(bool isHack)
    {
        _view.buttonAudio.Play();
        if (!isHack)
        {
            if(_model.data.Data.Keys > 0)
            {
                _model.data.DebitingKey(1);
                await ShowCards(false);
            }
            else if(!buttonAnimation)
            {
                buttonAnimation = true;
                await UIAnimations.TransformShakeOnX(_view.openButton.transform);
                buttonAnimation = false;
            }
        }
        else
        {
            if(_model.data.Data.MasterKeys > 0)
            {
                _model.data.DebitingMasterKey(1);
                await ShowCards(true);
            }
            else if(!buttonAnimation)
            {
                buttonAnimation = true;
                await UIAnimations.TransformShakeOnX(_view.hackButton.transform);
                buttonAnimation = false;
            }
        }
    }

    private async UniTask ShowCards(bool isCrack)
    {
        var cardShowController = GetCardShowController();

        _view.openChestEffect.SetActive(true);
        await MinimizeOpenScreen();

        if (_model.currentChest.chestName == _model.upgradeChest.chestName)
        {
            await cardShowController.StartMisteryBoxShow();
            DeleteMisteryBoxInInventory();
        }
        else
        {
            await cardShowController.StartCardsShow(isCrack);
        }

        _model.data.reloadInventory();
        await CloseOpenScreen();
        _view.openChestEffect.SetActive(false);
    }

    public void DeleteMisteryBoxInInventory()
    {
        for (var i = 0; i < _model.data.Data.ChestInventory.Count; i++)
        {
            if (_model.data.Data.ChestInventory[i].chestName == _model.currentChest.chestName)
            {
                _model.data.Data.ChestInventory.RemoveAt(i);
                break;
            }
        }
    }

    public async UniTask ChestUpgrade()
    {
        _view.buttonAudio.Play();
        if (!CheckChestContain(_model.upgradeChest))
        {
            _model.data.Data.ChestInventory.Add(_model.upgradeChest);
            _view.upgradeButton.gameObject.SetActive(false);
            CloseOpenScreen();
            _model.data.reloadInventory();
            _model.data.reloadInventory();

        }
        else
        {
            await UIAnimations.TransformShakeOnX(_view.upgradeButton.transform);
        }
    }

    private bool CheckChestContain(ChestInfo chest)
    {
        foreach(var inventoryChest in _model.data.Data.ChestInventory)
        {
            if (inventoryChest.chestName == chest.chestName)
                return true;
        }
        return false;
    }

    private CardsShowController<CardsShowView, CardsShowModel> GetCardShowController()
    {
        var cardShowModel = Resources.Load<CardsShowModel>("CardsShowModel");
        cardShowModel.data = _model.data;
        cardShowModel.currentChest = _model.currentChest;
        var cardShowView = _view.cardShowView;
        var controller = new CardsShowController<CardsShowView, CardsShowModel> (cardShowView, cardShowModel);
        return controller;
    }
}
public enum CombinationType
{
    standart,
    bonus,
    win
}