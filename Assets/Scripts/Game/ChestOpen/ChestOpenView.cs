using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpenView : MonoBehaviour, IView
{
    
    [SerializeField] internal Button hackButton;
    [SerializeField] internal Button openButton;
    [SerializeField] internal Button closeButton;
    [SerializeField] internal Button upgradeButton;
    [SerializeField] internal Image preview;

    [SerializeField] internal GameObject cardPositions;
    [SerializeField] internal GameObject showCardEffect;
    [SerializeField] internal GameObject openChestEffect;

    internal GameObject currentCard;
    internal GameObject currentWinCombinationPref;
    internal List<GameObject> currentCardsCombination;

    public void InstantiateNewCard(GameObject cardPref)
    {
        currentCard = Instantiate(cardPref, new Vector2(0, -9), Quaternion.identity, transform);
        if(currentCardsCombination == null)
            currentCardsCombination = new List<GameObject>();
        currentCardsCombination.Add(currentCard);
    }

    public void InstantiateCardCombination(GameObject winCombinationPref)
    {
        currentWinCombinationPref = Instantiate(winCombinationPref, new Vector2(0, 0), Quaternion.identity, transform);
    }

    public void DestroyCurrentCardCombination()
    {
        if(currentCardsCombination != null)
            foreach(var card in currentCardsCombination)
                if(card != null)
                    Destroy(card);
        currentCardsCombination = null;
    }

    public void DestroyCurrentWinCombination()
    {
        Destroy(currentWinCombinationPref);
    }
}
