using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour, IView
{
    [SerializeField] internal CanvasGroup group;
    [SerializeField] internal Button closeButton;
    [SerializeField] internal GameObject grid;
    [SerializeField] internal CanvasGroup effect;
    [SerializeField] internal AudioSource buttonSound;
}
