using ChestGame.Data;
using ChestGame.Game.Controllers;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Models
{
    [CreateAssetMenu(fileName = "ShopModel")]
    public class ShopModel : ScriptableObject, IModel
    {
        internal PlayerDataController Data;
        internal ChestInventoryController<ChestInventoryView, ChestInventoryModel> ChestInventoryController;
    }
}

