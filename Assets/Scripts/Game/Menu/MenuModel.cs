using UnityEngine;

namespace ChestGame.Game.Models
{
    [CreateAssetMenu(fileName = "MenuModel")]
    public class MenuModel : ScriptableObject, IModel
    {
        [SerializeField] internal Sprite ButtonEnabled;
        [SerializeField] internal Sprite ButtonDisabled;

        internal GameObject CurrentScreen;
        internal GameObject CurrentButton;
    }
}

