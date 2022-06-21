using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Module.ScriptableModule
{
    [CreateAssetMenu(fileName = "WinCombination")]
    public class WinCombinationInfo : ScriptableObject
    {
        [SerializeField] internal Combination Combination;
        [SerializeField] internal PriceType Price;
    }

    
}

enum PriceType
{
    coin5 = 5, 
    coin10 = 10, 
    coin50 = 50
}