using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRandomizerModule
{
    private List<CardInfo> _cards;
    private List<BonusCombinationInfo> _bonusCombinations;
    internal List<CardInfo> _currentWinCombination;
    internal BonusCombinationInfo _currentBonusCombination;
    private int generationSeed = 2;
    public CardRandomizerModule(List<CardInfo> cards, List<BonusCombinationInfo> bonusCombinations)
    {
        _cards = cards;
        _bonusCombinations = bonusCombinations; 
        _currentWinCombination = new List<CardInfo>();
        var random = new System.Random();
        var bonusIndex = random.Next(0, _bonusCombinations.Count);
        _currentBonusCombination = _bonusCombinations[bonusIndex];
        Debug.Log(_currentBonusCombination);
    }

    public CardInfo GetRandomCard()
    {
        generationSeed += 12;
        var random = new System.Random(generationSeed);
        var cardIndex = random.Next(0, _cards.Count);
        return _cards[cardIndex];
    }

    public List<CardInfo> GetWinCombination()
    {
        _currentWinCombination = new List<CardInfo>();
        for(int i = 0; i < 3; i++)
        {
            _currentWinCombination.Add(GetRandomCard());
        }
        return _currentWinCombination;
    }

    public BonusCombinationInfo GetBonusCombination()
    {
        generationSeed += 12;
        var random = new System.Random(generationSeed);
        var cardIndex = random.Next(0, _bonusCombinations.Count);
        return _bonusCombinations[cardIndex];
    }
}
