using UnityEngine;
using UnityEngine.UI;

namespace ChestGame.Game.View
{
    public class MenuView : MonoBehaviour, IView
    {
        [SerializeField] internal Button CardInventoryButton;
        [SerializeField] internal Button ChestInventoryButton;
        [SerializeField] internal Button ShopButton;

        [SerializeField] internal GameObject ShopScreen;
        [SerializeField] internal GameObject CardInventoryScreen;
        [SerializeField] internal GameObject ChestInventoryScreen;

        [SerializeField] internal AudioSource ButtonAudio;
    }
}

