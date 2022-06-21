using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Data
{
    public class StatisticData
    {
        private int _chestOpenNumber;
        private int _tokenCollectedNumber;
        private int _keycollectedNumber;
        private int _winNumber;
        private int _bonusNumber;
        public int ChestOpenNumber
        {
            get { return _chestOpenNumber; }
            set
            {
                _chestOpenNumber = value;
                ChangeStatistic();
            }
        }

        public int TokenCollectedNumber
        {
            get { return _tokenCollectedNumber; }
            set
            {
                _tokenCollectedNumber = value;
                ChangeStatistic();

            }
        }

        public int KeyCollectedNumber
        {
            get { return _keycollectedNumber; }
            set
            {
                _keycollectedNumber = value;
                ChangeStatistic();

            }
        }

        public int WinNumber
        {
            get { return _winNumber; }
            set
            {
                _winNumber = value;
                ChangeStatistic();

            }
        }

        public int BonusNumber
        {
            get { return _bonusNumber; }
            set
            {
                _bonusNumber = value;
                ChangeStatistic();

            }
        }

        public Action ChangeStatistic = default;

    }
}

