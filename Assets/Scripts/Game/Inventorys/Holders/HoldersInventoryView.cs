using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldersInventoryView : MonoBehaviour
{
    [SerializeField] internal Button closeButton;
    [SerializeField] internal GameObject grid;
    [SerializeField] internal CardsPresenterModule cardPresenterModule;
    [SerializeField] internal GameObject cardPositions;
    internal bool ScreenIsShow = false;

}
