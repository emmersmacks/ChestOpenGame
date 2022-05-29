using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardsInventoryModel")]
public class CardInventoryModel : ScriptableObject, IModel
{
    internal PlayerDataController data;
    internal ChestOpenController<ChestOpenView, ChestOpenModel> chestOpenController;
}
