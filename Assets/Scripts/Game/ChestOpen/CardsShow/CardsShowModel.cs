using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardsShowModel")]
public class CardsShowModel : ScriptableObject, IModel
{
    internal CardRandomizer cardRandomizer;
    internal PlayerDataController data;
    internal ChestInfo currentChest;


    [SerializeField] internal GameObject cardPref;
    [SerializeField] internal GameObject winCombinationPref;
    [SerializeField] internal List<CardInfo> allCards;
    [SerializeField] internal List<BonusCombinationInfo> bonusCombinations;
}
