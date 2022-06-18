using System.Collections.Generic;
using UnityEngine;
using System;

namespace ChestGame.Game.Module.ScriptableModule
{
    [CreateAssetMenu(fileName = "BonusCombination")]
    public class BonusCombinationInfo : ScriptableObject
    {
        [SerializeField] internal int DaysToHolder;
        [SerializeField] internal int HourseToHolder;
        [SerializeField] internal int MinuteToHolder;
        [SerializeField] internal int SecondToHolder;

        [SerializeField] internal Combination Combination;

        internal DateTime TimeToHolder;

        public BonusCombinationInfo()
        {
            TimeToHolder = new DateTime();
            TimeToHolder = TimeToHolder.AddSeconds(SecondToHolder);
            TimeToHolder = TimeToHolder.AddMinutes(MinuteToHolder);
            TimeToHolder = TimeToHolder.AddHours(HourseToHolder);
            TimeToHolder = TimeToHolder.AddDays(DaysToHolder);
        }
    }

    [Serializable]
    public class Combination
    {
        [SerializeField] private CardInfo _firstCard;
        [SerializeField] private CardInfo _secondCard;
        [SerializeField] private CardInfo _thirdCard;

        internal List<CardInfo> AllCards;

        public Combination()
        {
            AllCards = new List<CardInfo>();
            AllCards.Add(_firstCard);
            AllCards.Add(_secondCard);
            AllCards.Add(_thirdCard);
        }

        public CardInfo FirstCard { get => _firstCard; set => _firstCard = value; }
        public CardInfo SecondCard { get => _secondCard; set => _secondCard = value; }
        public CardInfo ThirdCard { get => _thirdCard; set => _thirdCard = value; }
    }
}
