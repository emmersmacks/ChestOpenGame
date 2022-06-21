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
        [SerializeField] internal GameObject TokenBonusPref;

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

        public void DestroyCurrentCardCombination()
        {
            if (CurrentCardsCombination != null)
                foreach (var card in CurrentCardsCombination)
                    if (card != null)
                        Destroy(card);
            CurrentCardsCombination = null;
        }
    }
}

