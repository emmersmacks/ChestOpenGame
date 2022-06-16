using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticView : MonoBehaviour
{
    [SerializeField] internal Text openChestCount;
    [SerializeField] internal Text tokenCollectedCount;
    [SerializeField] internal Text keyCollectedCount;
    [SerializeField] internal Text winCount;
    [SerializeField] internal Text bonusCombinationsCount;

    public void SetTextInField(Text field, string text)
    {
        field.text = text;
    }
}
