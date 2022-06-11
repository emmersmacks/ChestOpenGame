using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryView : MonoBehaviour, IView
{
    [SerializeField] internal GameObject grid;
    [SerializeField] internal Sprite slotsBackground;
    [SerializeField] internal GameObject cardPositions;
    [SerializeField] internal ChestOpenView chestOpenView;

    internal GameObject currentCard;
    internal bool screenIsShow = false;

    public Action OnClick = default;

    public void InstantiateNewCard(GameObject cardPref)
    {
        currentCard = Instantiate(cardPref, new Vector2(0, -9), Quaternion.identity, transform);
    }

    public void DestroyCard()
    {
        Destroy(currentCard);
    }

    private void Update()
    {
        if (screenIsShow)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                OnClick();
            }
        }
    }
    
}
