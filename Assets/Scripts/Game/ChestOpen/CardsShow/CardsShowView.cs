using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsShowView : MonoBehaviour, IView
{
    [SerializeField] internal GameObject showCardEffect;
    [SerializeField] internal GameObject cardPositions;
    [SerializeField] internal GameObject cardPosition;
    [SerializeField] internal AudioSource winCombinationAudio;

    internal GameObject currentCard;
    internal GameObject currentWinCombinationPref;
    internal List<GameObject> currentCardsCombination;

    public void InstantiateNewCard(GameObject cardPref)
    {
        currentCard = Instantiate(cardPref, new Vector2(0, -9), Quaternion.identity, transform.parent);

        if (currentCardsCombination == null)
            currentCardsCombination = new List<GameObject>();

        currentCardsCombination.Add(currentCard);
    }

    public void InstantiateCardWinCombination(GameObject winCombinationPref)
    {
        currentWinCombinationPref = Instantiate(winCombinationPref, new Vector2(0, 0), Quaternion.identity, transform);
    }

    public void DestroyCurrentCardCombination()
    {
        if (currentCardsCombination != null)
            foreach (var card in currentCardsCombination)
                if (card != null)
                    Destroy(card);
        currentCardsCombination = null;
    }

    public void DestroyCurrentWinCombination()
    {
        Destroy(currentWinCombinationPref);
    }

}
