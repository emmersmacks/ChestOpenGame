using ChestGame.Data;
using ChestGame.Game.Controllers;
using ChestGame.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Models
{
    [CreateAssetMenu(fileName = "CardsInventoryModel")]
    public class CardInventoryModel : ScriptableObject, IModel
    {
        internal PlayerDataController Data;
        internal GameObject CurrentCard;
        internal ChestOpenController<ChestOpenView, ChestOpenModel> ChestOpenController;
        [SerializeField] internal GameObject CardPrefab;
    }
}

