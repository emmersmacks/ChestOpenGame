using ChestGame.Game.Controllers;
using ChestGame.Game.View;
using UnityEngine;

namespace ChestGame.Game.Applications
{
    public class UIApplication : MonoBehaviour, IApplication
    {
        [SerializeField] private UIView _uiView;

        private UIController _uiController;

        public UIController InstanceApplication()
        {
            _uiController = new UIController(_uiView);
            return _uiController;
        }
    }
}

