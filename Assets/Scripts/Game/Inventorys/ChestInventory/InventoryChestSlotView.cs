using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryChestSlotView : MonoBehaviour, IView
{
    [SerializeField] internal Image preview;
    [SerializeField] internal Button button;
    [SerializeField] internal Transform defaultPositionPreview;
    [SerializeField] internal Transform zoomPozitionPreview;
    

    internal ChestInfo chest;
    internal Vector3 defaultPosition;
}
