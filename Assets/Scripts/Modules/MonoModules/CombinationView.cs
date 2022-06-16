using UnityEngine;
using UnityEngine.UI;

public class CombinationView : MonoBehaviour, IView
{
    [SerializeField] internal Image FirstCardPreview;
    [SerializeField] internal Image SecondCardPreview;
    [SerializeField] internal Image ThirdCardPreview;
    [SerializeField] internal TimerModule timerModule;
}
