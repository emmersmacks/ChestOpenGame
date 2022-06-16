using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine.UI;

public static class UIAnimations
{
    public static async UniTask SlideUpAnimation(GameObject obj)
    {
        obj.transform.position = new Vector3(0, -10);
        var tween = obj.transform.DOMoveY(0, 0.5f);
        await tween.AsyncWaitForCompletion();
    }

    public static async UniTask WindowSlideDownAnimation(GameObject window)
    {
        var tween = window.transform.DOMoveY(-10, 0.5f);
        await tween.AsyncWaitForCompletion();
    }

    public static async UniTask SlideToPointAnimation(Vector3 point, Transform obj)
    {
        var tween = obj.transform.DOMove(point, 0.5f);
        await tween.AsyncWaitForCompletion();
    }

    public static async UniTask TransformShakeOnX(Transform transform)
    {
        var tween = transform.DOShakePosition(0.5f, new Vector3(10, 0));
        await tween.AsyncWaitForCompletion();
    }

    public static async UniTask ScaleZoom(Transform transform)
    {
        var tween = transform.DOScale(2f ,0.5f);
        await tween.AsyncWaitForCompletion();
    }

    public static async UniTask ScaleMinimaze(Transform transform)
    {
        var tween = transform.DOScale(1, 0.5f);
        await tween.AsyncWaitForCompletion();
    }

    public static async UniTask FadeColorToDark(Image image)
    {
        var tween = image.DOFade(0.8f, 0.5f);
        await tween.AsyncWaitForCompletion();
    }

    public static async UniTask FadeColorToWhite(Image image)
    {
        var tween = image.DOFade(0f, 0.5f);
        await tween.AsyncWaitForCompletion();
    }
}
