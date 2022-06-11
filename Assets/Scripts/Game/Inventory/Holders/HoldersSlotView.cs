using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class HoldersSlotView : MonoBehaviour, IView
{
    [SerializeField] internal Image firstCardPreview;
    [SerializeField] internal Image secondCardPreview;
    [SerializeField] internal Image thirdCardPreview;
    [SerializeField] internal Button openButton;
    [SerializeField] internal Image timeCounterObject;
    [SerializeField] internal Text timeCounterText;
    internal DateTime timer = new DateTime();
    internal bool timerIsStart = false;

    public async UniTask StartTimer()
    {
        timer = timer.AddMinutes(10);
        timerIsStart = true;
        timeCounterObject.gameObject.SetActive(true);
        Debug.Log(timer);
        while(true)
        {
            if (timer.Day + timer.Hour + timer.Minute + timer.Second == 0)
                break;
            timer = timer.Subtract(new TimeSpan(0, 0, 1));
            timeCounterText.text = string.Format("Days: {0} {1}:{2}:{3}", timer.Day, timer.Hour, timer.Minute, timer.Second);
            await UniTask.Delay(1000);
        }
    }


}
