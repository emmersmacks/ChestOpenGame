using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class OrientationController : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] Button fulscreen;

    [DllImport("__Internal")] private static extern bool IsMobile();

    private void Start()
    {
        fulscreen.onClick.RemoveAllListeners();
        fulscreen.onClick.AddListener(EnableFulscreen);

        if (IsMobile())
        {
            fulscreen.gameObject.SetActive(true);
        }
        else
            fulscreen.gameObject.SetActive(false);
    }

    private void EnableFulscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
