using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpenView : MonoBehaviour
{
    [SerializeField] internal ChestInfo defaultChest;
    [SerializeField] internal ChestInfo upgradeChest;
    [SerializeField] internal Button hackButton;
    [SerializeField] internal Button openButton;
    [SerializeField] internal Button closeButton;
    [SerializeField] internal Button upgradeButton;
    [SerializeField] internal Image preview;
    [SerializeField] private GameObject cardPref;
    [SerializeField] private GameObject winCombinationPref;
    [SerializeField] internal GameObject cardPositions;
    [SerializeField] internal GameObject showCardEffect;
    [SerializeField] internal GameObject openChestEffect;
    internal GameObject currentCard;
    internal List<GameObject> currentCardsCombination;
    internal GameObject currentWinCombinationPref;

    public void InstantiateNewCard()
    {
        currentCard = Instantiate(cardPref, new Vector2(0, -9), Quaternion.identity, transform);
        if(currentCardsCombination == null)
            currentCardsCombination = new List<GameObject>();
        currentCardsCombination.Add(currentCard);
    }

    public void InstantiateCardCombination()
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
