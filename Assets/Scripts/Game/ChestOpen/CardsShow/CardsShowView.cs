using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.View
{
    public class CardsShowView : MonoBehaviour, IView
    {
        [SerializeField] internal GameObject ShowCardEffect;
        [SerializeField] internal GameObject CardPositions;
        [SerializeField] internal GameObject CardPosition;
        [SerializeField] internal AudioSource WinCombinationAudio;

        internal GameObject CurrentCard;
        internal GameObject CurrentWinCombinationPref;
        internal List<GameObject> CurrentCardsCombination;

        public void InstantiateNewCard(GameObject cardPref)
        {
            CurrentCard = Instantiate(cardPref, new Vector2(0, -9), Quaternion.identity, transform.parent);

            if (CurrentCardsCombination == null)
                CurrentCardsCombination = new List<GameObject>();

            CurrentCardsCombination.Add(CurrentCard);
        }

        public void InstantiateCardWinCombination(GameObject winCombinationPref)
        {
            CurrentWinCombinationPref = Instantiate(winCombinationPref, new Vector2(0, 0), Quaternion.identity, transform);
        }

        public void DestroyCurrentCardCombination()
        {
            if (CurrentCardsCombination != null)
                foreach (var card in CurrentCardsCombination)
                    if (card != null)
                        Destroy(card);
            CurrentCardsCombination = null;
        }

        public void DestroyCurrentWinCombination()
        {
            Destroy(CurrentWinCombinationPref);
        }

    }
}

