using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestInventoryView : MonoBehaviour, IView
{
    [SerializeField] internal GameObject grid;
    [SerializeField] internal Sprite slotsBackground;
    [SerializeField] internal GameObject cardPositions;
    [SerializeField] internal ChestOpenView chestOpenView;
    [SerializeField] internal CombinationView combinationView;
    [SerializeField] internal StatisticView statisticView;
    [SerializeField] internal BonusCombinationsView bonusCombinationView;

    internal GameObject currentCard;
    internal bool screenIsShow = false;

    public void InstantiateNewCard(GameObject cardPref)
    {
        currentCard = Instantiate(cardPref, new Vector2(0, -9), Quaternion.identity, transform);
    }

    public void DestroyCard()
    {
        Destroy(currentCard);
    }
}
