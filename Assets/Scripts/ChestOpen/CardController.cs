using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController
{
    private List<CardInfo> _cards;

    public CardController(List<CardInfo> cards)
    {
        _cards = cards;
    }

    public CardInfo GetRandomCard()
    {
        var cardIndex = Random.Range(0, _cards.Count);
        return _cards[cardIndex];
    }

    public List<CardInfo> GetWinCombination()
    {
        var winCombination = new List<CardInfo>();
        for(int i = 0; i < 3; i++)
        {
            winCombination.Add(GetRandomCard());
        }
        return winCombination;
    }
}
