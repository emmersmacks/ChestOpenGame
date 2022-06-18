using ChestGame.Data;
using ChestGame.Game.Controllers;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Models
{
    [CreateAssetMenu(fileName = "HolderInventoryModel")]
    public class HoldersModel : ScriptableObject, IModel
    {
        internal PlayerDataController Data;
        internal ChestOpenController<ChestOpenView, ChestOpenModel> ChestOpenController;
        internal GameObject CurrentCard;

        [SerializeField] internal GameObject CardPrefab;
    }
}

