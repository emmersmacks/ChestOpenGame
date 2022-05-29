using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public static class OpenChestAnimations
{
    public static async UniTask SlideUpAnimation(GameObject obj)
    {
        while (obj.transform.position.y < 0)
        {
            var cardTransform = obj.transform;
            cardTransform.position = new Vector3(cardTransform.position.x, cardTransform.position.y + 0.4f);
            await UniTask.Delay(10);
        }
    }

    public static async UniTask WindowSlideDownAnimation(GameObject window)
    {
        while (window.transform.position.y > -10)
        {
            var windowsTransform = window.transform;
            windowsTransform.position = new Vector3(windowsTransform.position.x, windowsTransform.position.y - 0.2f);
            await UniTask.Delay(7);
        }
    }

    public static async UniTask SlideToPointAnimation(ChestOpenView view, int index)
    {
        var direction = view.cardPositions.transform.GetChild(index).position - view.currentCard.transform.position;
        while (view.currentCard.transform.position != view.cardPositions.transform.GetChild(index).position)
        {
            view.currentCard.transform.position = Vector3.MoveTowards(view.currentCard.transform.position, view.cardPositions.transform.GetChild(index).position, 3);
            await UniTask.Delay(10);
        }
    }
}
