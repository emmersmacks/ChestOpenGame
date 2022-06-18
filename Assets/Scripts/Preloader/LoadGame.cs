using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using ChestGame.Game.Animations;

namespace ChestGame.Preloader
{
    public class LoadGame : MonoBehaviour
    {
        [SerializeField] private Image _image;
        void Start()
        {
            ShowScreensaver();
        }

        private async UniTask ShowScreensaver()
        {
            await UIAnimations.FadeColorToWhite(_image);
            await UniTask.Delay(1000);
            SceneManager.LoadScene(1);
        }
    }
}

