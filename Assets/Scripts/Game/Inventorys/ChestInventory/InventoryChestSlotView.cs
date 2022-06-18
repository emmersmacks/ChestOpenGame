using ChestGame.Game.Module.ScriptableModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestGame.Game.View
{
    public class InventoryChestSlotView : MonoBehaviour, IView
    {
        [SerializeField] internal Image Preview;
        [SerializeField] internal Button Button;
        [SerializeField] internal Transform DefaultPositionPreview;
        [SerializeField] internal Transform ZoomPozitionPreview;


        internal ChestInfo Chest;
        internal Vector3 DefaultPosition;
    }
}

