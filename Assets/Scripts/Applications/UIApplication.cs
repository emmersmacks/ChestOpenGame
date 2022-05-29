using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIApplication : MonoBehaviour, IApplication
{
    [SerializeField] private UIView _uiView;

    private UIController _uiController;

    public UIController InstanceApplication()
    {
        _uiController = new UIController(_uiView);
        return _uiController;
    }
}
