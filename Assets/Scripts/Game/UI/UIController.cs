using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController
{
    private PanelsView _panelsView;

    public UIController(UIView view)
    {
        _panelsView = view.panels;
    }

    public void Init(PlayerDataController data)
    {
        UpdateDiamondPanel(data);
        UpdateTokenPanel(data);
        UpdateKeyPanel(data);
        UpdateMasterKeyPanel(data);
    }

    public void UpdateDiamondPanel(PlayerDataController data)
    {
        _panelsView.diamondText.text = data.Data.Diamond.ToString();
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
}
