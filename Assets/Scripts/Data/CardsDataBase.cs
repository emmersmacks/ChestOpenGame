using ChestGame.Game.Models;
using ChestGame.Game.Module.ScriptableModule;
using ChestGame.Game.Module.ScriptModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Data
{
    [CreateAssetMenu(fileName = "CardsShowModel")]
    public class CardsDataBase : ScriptableObject, IModel
    {
        internal CardRandomizerModule CardRandomizer;
        internal PlayerDataController Data;
        internal ChestInfo CurrentChest;

        [SerializeField] internal GameObject CardPref;
        [SerializeField] internal GameObject WinCombinationPref;
        [SerializeField] internal List<CardInfo> AllCards;
        [SerializeField] internal List<CardInfo> MisteryCards;
        [SerializeField] internal List<BonusCombinationInfo> BonusCombinations;
    }
}

