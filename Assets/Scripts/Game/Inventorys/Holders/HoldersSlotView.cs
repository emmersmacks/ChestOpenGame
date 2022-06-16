using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class HoldersSlotView : MonoBehaviour, IView
{
    [SerializeField] internal CombinationView CombinationView;
    [SerializeField] internal Button OpenButton;
    [SerializeField] internal Image TimeCounterObject;
    [SerializeField] internal TimerModule TimerModule;
}
