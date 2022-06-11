using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BonusCombination")]
public class BonusCombinationInfo : ScriptableObject
{
    [SerializeField] internal List<CardInfo> cards;
    [SerializeField] internal int daysToHolder;
    [SerializeField] internal int hourseToHolder;
    [SerializeField] internal int minuteToHolder;
    [SerializeField] internal int secondToHolder;
}
