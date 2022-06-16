using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CardsInventoryView : MonoBehaviour, IView
{
    [SerializeField] internal GameObject grid;
    [SerializeField] internal Sprite slotsBackground;
    [SerializeField] internal GameObject cardPositions;
    [SerializeField] internal Button closePresenterButton;
    [SerializeField] internal CardsPresenterModule cardPresenterModule;
    
    internal bool ScreenIsShow = false;
}
