using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestInventoryModel")]
public class ChestInventoryModel : ScriptableObject, IModel
{
    internal PlayerDataController data;
}
