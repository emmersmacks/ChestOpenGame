using ChestGame.Data;
using ChestGame.Game.Module.ScriptableModule;
using ChestGame.Game.View;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Models
{
    [CreateAssetMenu(fileName = "ChestOpenModel")]
    public class ChestOpenModel : ScriptableObject, IModel
    {
        internal PlayerDataController Data;
        internal ChestInfo CurrentChest;
        internal InventoryChestSlotView SlotView;
        internal Vector3 DefaultButtonPosition;
        internal GameObject Inventory;

        [SerializeField] internal ChestInfo DefaultChest;
        [SerializeField] internal ChestInfo UpgradeChest;

    }
}

