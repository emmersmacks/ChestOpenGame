using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

namespace ChestGame.Game.Module.MonoModule
{
    public class TimerModule : MonoBehaviour
    {
        [SerializeField] internal Text TimeCounterText;

        internal DateTime Timer = new DateTime();
        internal bool TimerIsStart = false;
        private float _millisecondsCounter = 0;

        public async UniTask StartTimer()
        {
            Timer = Timer.AddMinutes(10);
            TimerIsStart = true;
            Debug.Log(Timer);
        }

        private void Update()
        {
            if (TimerIsStart)
            {
                _millisecondsCounter += Time.deltaTime;
                if (_millisecondsCounter >= 1)
                {
                    _millisecondsCounter = 0;
                    if (Timer.Day + Timer.Hour + Timer.Minute + Timer.Second == 0)
                        throw new Exception("Time prize is passed, add logic in TimerModule for anyway action");
                    Timer = Timer.Subtract(new TimeSpan(0, 0, 1));
                    TimeCounterText.text = string.Format("Days: {0} {1}:{2}:{3}", Timer.Day, Timer.Hour, Timer.Minute, Timer.Second);
                }
            }
        }
    }
}

