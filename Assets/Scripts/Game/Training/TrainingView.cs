using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestGame.Game.View
{
    public class TrainingView : MonoBehaviour, IView
    {
        [SerializeField] internal GameObject MainScreen;
        [SerializeField] internal GameObject OpenChestScreen;
        [SerializeField] internal Button NextPageButton;
    }
}

