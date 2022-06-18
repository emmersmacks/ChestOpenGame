using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestGame.Game.View
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] public PanelsView Panels;
        [SerializeField] internal ShopView ShopWindow;
        [SerializeField] internal Button KeyShopButton;
        [SerializeField] internal Button TrainingButton;
        [SerializeField] internal TrainingView TrainingView;
        [SerializeField] internal GameObject TrainingArrow;
        [SerializeField] internal AudioSource ButtonAudio;
    }
}

