using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField] internal Button cardInventoryButton;
    [SerializeField] internal Button chestInventoryButton;
    [SerializeField] internal Button shopButton;

    [SerializeField] internal GameObject shopScreen;
    [SerializeField] internal GameObject cardInventoryScreen;
    [SerializeField] internal GameObject chestInventoryScreen;

    [SerializeField] internal Sprite enableSprite;
    [SerializeField] internal Sprite disableSprite;
}
