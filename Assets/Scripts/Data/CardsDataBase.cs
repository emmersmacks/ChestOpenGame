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
        [SerializeField] internal GameObject CardPref;

        [SerializeField] internal List<CardInfo> AllCards;
        [SerializeField] internal List<CardInfo> MisteryCards;
        [SerializeField] internal List<BonusCombinationInfo> BonusCombinations;
        [SerializeField] internal List<WinCombinationInfo> WinCombinations;
    }
}

