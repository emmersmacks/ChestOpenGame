using ChestGame.Data;
using ChestGame.Game.Module.ScriptableModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Module.ScriptModule
{
    public class CardRandomizerModule
    {
        private CardsDataBase _cardsData;
        private List<CardInfo> _cards;
        private List<BonusCombinationInfo> _bonusCombinations;
        private List<WinCombinationInfo> _winCombinations;

        internal WinCombinationInfo CurrentWinCombination;
        internal BonusCombinationInfo CurrentBonusCombination;
        private int _generationSeed = 2;
        public CardRandomizerModule(CardsDataBase cardData)
        {
            _cardsData = cardData;
            _cards = cardData.AllCards;
            _bonusCombinations = cardData.BonusCombinations;
            _winCombinations = cardData.WinCombinations;
            var random = new System.Random();
            var bonusIndex = random.Next(0, _bonusCombinations.Count);
            var winIndex = random.Next(0, _winCombinations.Count);
            CurrentBonusCombination = _bonusCombinations[bonusIndex];
            CurrentWinCombination = _winCombinations[winIndex];
        }

        public CardInfo GetRandomCard()
        {
            _generationSeed += 12;
            var random = new System.Random(_generationSeed);
            var cardIndex = random.Next(0, _cards.Count);
            return _cards[cardIndex];
        }

        public List<CardInfo> GetRandomCombination()
        {
            var combination = new List<CardInfo>();
            for (int i = 0; i < 3; i++)
            {
                combination.Add(GetRandomCard());
            }
            return combination;
        }

        public CardInfo GetRandomMisteryCard()
        {
            _generationSeed += 12;
            var random = new System.Random(_generationSeed);
            var cardIndex = random.Next(0, _cards.Count);
            return _cardsData.MisteryCards[cardIndex];
        }
    }
}

