using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.Module.MonoModule
{
    public class CardsPresenterModule : MonoBehaviour
    {
        public GameObject InstantiateNewCard(GameObject cardPref)
        {
            var currentCard = Instantiate(cardPref, new Vector2(0, -9), Quaternion.identity, transform);
            return currentCard;
        }

        public void DestroyCard(GameObject cardObject)
        {
            Destroy(cardObject);
        }
    }
}

