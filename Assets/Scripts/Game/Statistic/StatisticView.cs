using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestGame.Game.View
{
    public class StatisticView : MonoBehaviour
    {
        [SerializeField] internal Text OpenChestCount;
        [SerializeField] internal Text TokenCollectedCount;
        [SerializeField] internal Text KeyCollectedCount;
        [SerializeField] internal Text WinCount;
        [SerializeField] internal Text BonusCombinationsCount;

        public void SetTextInField(Text field, string text)
        {
            field.text = text;
        }
    }
}

