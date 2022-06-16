using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class LoadGame : MonoBehaviour
{
    [SerializeField] Image image;
    void Start()
    {
        ShowScreensaver();
    }

    private async UniTask ShowScreensaver()
    {
        await UIAnimations.FadeColorToWhite(image);
        await UniTask.Delay(1000);
        SceneManager.LoadScene(1);
    }
}
