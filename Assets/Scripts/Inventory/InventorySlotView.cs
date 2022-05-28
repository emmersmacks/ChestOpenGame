using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField] internal Image preview;
    [SerializeField] internal Text countText;
    [SerializeField] internal Button button;

    internal ChestInfo chest;
}
