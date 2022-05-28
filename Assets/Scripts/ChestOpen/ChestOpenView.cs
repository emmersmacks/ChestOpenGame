using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpenView : MonoBehaviour
{
    [SerializeField] internal Button hackButton;
    [SerializeField] internal Button openButton;
    [SerializeField] internal Button closeButton;
    [SerializeField] internal Image preview;
    [SerializeField] private GameObject cardPref;
    [SerializeField] private GameObject winCombinationPref;
    internal GameObject currentCard;
    internal GameObject currentCombination;

    public void InstantiateNewCard()
    {
        currentCard = Instantiate(cardPref, new Vector2(0, -1), Quaternion.identity, transform);
    }

    public void InstantiateCardCombination()
    {
        currentCombination = Instantiate(winCombinationPref, new Vector2(0, 0), Quaternion.identity, transform);
    }

    public void DestroyCurrentCard()
    {
        Destroy(currentCard);
    }

    public void DestroyCurrentCombination()
    {
        Destroy(currentCombination);
    }
}
