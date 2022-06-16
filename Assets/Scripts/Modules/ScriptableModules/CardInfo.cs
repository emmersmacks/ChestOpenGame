using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardInfo")]
public class CardInfo : ScriptableObject
{
    [SerializeField] private Sprite _cardSprite;
    public Sprite cardSprite => this._cardSprite;
}
