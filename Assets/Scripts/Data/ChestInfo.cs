using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Chest")]
public class ChestInfo : ScriptableObject
{
    [SerializeField] private Sprite _chestSprite;
    [SerializeField] private string _chestName;
    [SerializeField] private int _price;
    [SerializeField] internal int _count = 1;
    public Sprite chestSprite => this._chestSprite;
    public int price => this._price;
    public string chestName => this._chestName;
}
