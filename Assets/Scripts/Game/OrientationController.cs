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
    [DllImport("__Internal")] private static extern void Hello();

    private void Start()
    {
        fulscreen.onClick.AddListener(EnableFulscreen);
    }

    private void EnableFulscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    private void Update()
    {
        if(IsMobile())
        {
            fulscreen.gameObject.SetActive(true);
            //if ((Screen.orientation == ScreenOrientation.Landscape | Screen.width > Screen.height) & !Screen.fullScreen)
            //{
            //    screen.transform.localScale = new Vector3(70f, 70f, 70f);
            //    
            //}
            //else
            //{
            //    screen.transform.localScale = new Vector3(108, 108, 108);
            //}
        }
        else
            fulscreen.gameObject.SetActive(false);
    }
}
