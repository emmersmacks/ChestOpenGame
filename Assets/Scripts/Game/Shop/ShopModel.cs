using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopModel")]
public class ShopModel : ScriptableObject, IModel
{
    internal PlayerDataController data;
    internal UIController ui;
    internal ChestInventoryController<ChestInventoryView, ChestInventoryModel> chestInventoryController;
}
