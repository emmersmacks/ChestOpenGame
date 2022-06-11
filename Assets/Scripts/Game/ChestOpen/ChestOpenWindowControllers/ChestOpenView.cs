using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpenView : MonoBehaviour, IView
{
    
    [SerializeField] internal Button hackButton;
    [SerializeField] internal Button openButton;
    [SerializeField] internal Button closeButton;
    [SerializeField] internal Button upgradeButton;
    [SerializeField] internal Image preview;
    [SerializeField] internal CardsShowView cardShowView;
    [SerializeField] internal GameObject openChestEffect;
    [SerializeField] internal GameObject buttons;
    [SerializeField] internal AudioSource openChestAudio;
    [SerializeField] internal AudioSource buttonAudio;
}
