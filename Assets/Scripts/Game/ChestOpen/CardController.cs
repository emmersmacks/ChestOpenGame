using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController
{
    private List<CardInfo> _cards;
    internal List<CardInfo> _currentWinCombination;
    private int generationSeed = 2;
    public CardController(List<CardInfo> cards)
    {
        _cards = cards;
        _currentWinCombination = new List<CardInfo>();
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
}
