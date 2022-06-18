using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace ChestGame.Game.Module.ScriptableModule
{
    [CreateAssetMenu(fileName = "CardInfo")]
    public class CardInfo : ScriptableObject
    {
        [SerializeField] private Sprite _cardSprite;
        public Sprite CardSprite => this._cardSprite;
    }
}

