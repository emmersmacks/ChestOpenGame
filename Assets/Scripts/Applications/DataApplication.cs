using ChestGame.Data;
using ChestGame.Game.Controllers;
using UnityEngine;

namespace ChestGame.Game.Applications
{
    public class DataApplication : MonoBehaviour, IApplication
    {
        internal PlayerDataController dataController;

        public PlayerDataController InstanceApplication(UIController ui)
        {
            dataController = new PlayerDataController(ui);
            return dataController;
        }
    }
}

