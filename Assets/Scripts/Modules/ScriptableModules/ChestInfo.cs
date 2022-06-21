using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestGame.Game.Module.ScriptableModule
{
    [CreateAssetMenu(fileName = "Chest")]
    public class ChestInfo : ScriptableObject
    {
        [SerializeField] private Sprite _chestSprite;
        [SerializeField] private string _chestName;
        [SerializeField] private int _price;
        [SerializeField] internal int WinChanceInProcent;
        [SerializeField] internal int BonusChanceInProcaent;
        [SerializeField] internal int TokenBonusChanceInPercent;
        public Sprite ChestSprite => this._chestSprite;
        public int Price => this._price;
        public string ChestName => this._chestName;
    }
}

