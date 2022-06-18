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

        internal List<CardInfo> CurrentWinCombination;
        internal BonusCombinationInfo CurrentBonusCombination;
        private int _generationSeed = 2;
        public CardRandomizerModule(CardsDataBase cardData)
        {
            _cardsData = cardData;
            _cards = cardData.AllCards;
            _bonusCombinations = cardData.BonusCombinations;
            CurrentWinCombination = new List<CardInfo>();
            var random = new System.Random();
            var bonusIndex = random.Next(0, _bonusCombinations.Count);
            CurrentBonusCombination = _bonusCombinations[bonusIndex];
            Debug.Log(CurrentBonusCombination);
        }

        public CardInfo GetRandomCard()
        {
            _generationSeed += 12;
            var random = new System.Random(_generationSeed);
            var cardIndex = random.Next(0, _cards.Count);
            return _cards[cardIndex];
        }

        public List<CardInfo> GetWinCombination()
        {
            CurrentWinCombination = new List<CardInfo>();
            for (int i = 0; i < 3; i++)
            {
                CurrentWinCombination.Add(GetRandomCard());
            }
            return CurrentWinCombination;
        }

        public BonusCombinationInfo GetBonusCombination()
        {
            _generationSeed += 12;
            var random = new System.Random(_generationSeed);
            var cardIndex = random.Next(0, _bonusCombinations.Count);
            return _bonusCombinations[cardIndex];
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

