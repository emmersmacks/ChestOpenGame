using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController
{
    private PanelsView _panelsView;
    private PlayerDataController _data;

    public UIController(UIView view, PlayerDataController data)
    {
        _data = data;
        _panelsView = view.panels;
        Init();
    }

    public void Init()
    {
        UpdateDiamondPanel();
        UpdateTokenPanel();
        UpdateKeyPanel();
        UpdateMasterKeyPanel();
    }

    public void UpdateDiamondPanel()
    {
        _panelsView.diamondText.text = _data.Data.Diamond.ToString();
    }

    public void UpdateTokenPanel()
    {
        _panelsView.tokenText.text = _data.Data.Token.ToString();
    }

    public void UpdateKeyPanel()
    {
        _panelsView.keyText.text = _data.Data.Keys.ToString();
    }

    public void UpdateMasterKeyPanel()
    {
        _panelsView.masterKeyText.text = _data.Data.MasterKeys.ToString();
    }
}
