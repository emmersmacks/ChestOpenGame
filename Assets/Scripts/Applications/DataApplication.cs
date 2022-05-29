using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataApplication : MonoBehaviour, IApplication
{
    internal PlayerDataController dataController;

    public PlayerDataController InstanceApplication(UIController ui)
    {
        dataController = new PlayerDataController(ui);
        return dataController;
    }
}
