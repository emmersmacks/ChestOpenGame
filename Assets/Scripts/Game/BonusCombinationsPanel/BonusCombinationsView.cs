using ChestGame.Game.Module.ScriptableModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Game.View
{
    public class BonusCombinationsView : MonoBehaviour, IView
    {
        [SerializeField] internal GameObject ToncoinPanel5;
        [SerializeField] internal GameObject ToncoinPanel10;
        [SerializeField] internal GameObject ToncoinPanel50;

        [SerializeField] private GameObject _cardCombinationPrefab;

        public void AddCardCombination(GameObject panel, BonusCombinationInfo data)
        {
            var cardCombinationObject = Instantiate(_cardCombinationPrefab, panel.transform);
            var view = cardCombinationObject.GetComponent<CombinationView>();
            view.FirstCardPreview.sprite = data.Combination.FirstCard.CardSprite;
            view.SecondCardPreview.sprite = data.Combination.SecondCard.CardSprite;
            view.ThirdCardPreview.sprite = data.Combination.ThirdCard.CardSprite;
        }
    }
}

