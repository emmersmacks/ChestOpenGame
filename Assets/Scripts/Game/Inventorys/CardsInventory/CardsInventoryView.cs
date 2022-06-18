using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using ChestGame.Game.Module.MonoModule;

namespace ChestGame.Game.View
{
    public class CardsInventoryView : MonoBehaviour, IView
    {
        [SerializeField] internal GameObject Grid;
        [SerializeField] internal Sprite SlotsBackground;
        [SerializeField] internal GameObject CardPositions;
        [SerializeField] internal Button ClosePresenterButton;
        [SerializeField] internal CardsPresenterModule CardPresenterModule;

        internal bool ScreenIsShow = false;
    }
}

