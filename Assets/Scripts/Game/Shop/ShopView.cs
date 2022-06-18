using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestGame.Game.View
{
    public class ShopView : MonoBehaviour, IView
    {
        [SerializeField] internal CanvasGroup Group;
        [SerializeField] internal Button CloseButton;
        [SerializeField] internal GameObject Grid;
        [SerializeField] internal CanvasGroup Effect;
        [SerializeField] internal AudioSource ButtonSound;
    }
}

