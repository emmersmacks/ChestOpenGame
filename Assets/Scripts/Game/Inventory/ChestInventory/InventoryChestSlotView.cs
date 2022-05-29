using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryChestSlotView : MonoBehaviour, IView
{
    [SerializeField] internal Image preview;
    [SerializeField] internal Text countText;
    [SerializeField] internal Button button;

    internal ChestInfo chest;
}
