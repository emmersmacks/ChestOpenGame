using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestOpenModel")]
public class ChestOpenModel : ScriptableObject, IModel
{
    internal PlayerDataController data;
    internal ChestInfo currentChest;
    internal InventoryChestSlotView slotView;
    internal Vector3 defaultButtonPosition;
    internal GameObject inventory;

    [SerializeField] internal ChestInfo defaultChest;
    [SerializeField] internal ChestInfo upgradeChest;
   
}
