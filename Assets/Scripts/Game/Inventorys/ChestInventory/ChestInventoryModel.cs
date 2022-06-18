using ChestGame.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Models
{
    [CreateAssetMenu(fileName = "ChestInventoryModel")]
    public class ChestInventoryModel : ScriptableObject, IModel
    {
        internal PlayerDataController Data;
    }
}

