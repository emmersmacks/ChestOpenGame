using ChestGame.Game.Module.MonoModule;
using UnityEngine;
using UnityEngine.UI;

namespace ChestGame.Game.View
{
    public class CombinationView : MonoBehaviour, IView
    {
        [SerializeField] internal Image FirstCardPreview;
        [SerializeField] internal Image SecondCardPreview;
        [SerializeField] internal Image ThirdCardPreview;
        [SerializeField] internal TimerModule TimerModule;
    }
}

