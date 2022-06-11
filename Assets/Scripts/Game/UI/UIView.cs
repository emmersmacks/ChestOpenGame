using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] public PanelsView panels;
    [SerializeField] internal ShopView shopWindow;
    [SerializeField] internal Button keyShopButton;
    [SerializeField] internal Button trainingButton;
    [SerializeField] internal TrainingView trainingView;
    [SerializeField] internal GameObject trainingArrow;
    [SerializeField] internal AudioSource buttonAudio;
}
