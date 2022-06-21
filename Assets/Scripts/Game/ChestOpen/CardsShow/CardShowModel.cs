using ChestGame.Data;
using ChestGame.Game.Module.ScriptableModule;
using ChestGame.Game.Module.ScriptModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Models
{
    public class CardShowModel : IModel
    {
        internal CardRandomizerModule CardRandomizer;
        internal PlayerDataController Data;
        internal ChestInfo CurrentChest;
        internal CardsDataBase CardsData;
    }
}

