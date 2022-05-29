using UnityEngine;

[CreateAssetMenu(fileName = "MenuModel")]
public class MenuModel : ScriptableObject, IModel
{
    [SerializeField] internal Sprite buttonEnabled;
    [SerializeField] internal Sprite buttonDisabled;

    internal GameObject currentScreen;
    internal GameObject currentButton;
}
