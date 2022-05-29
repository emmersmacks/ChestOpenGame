using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour, IView
{
    [SerializeField] internal Button cardInventoryButton;
    [SerializeField] internal Button chestInventoryButton;
    [SerializeField] internal Button shopButton;

    [SerializeField] internal GameObject shopScreen;
    [SerializeField] internal GameObject cardInventoryScreen;
    [SerializeField] internal GameObject chestInventoryScreen;
}
