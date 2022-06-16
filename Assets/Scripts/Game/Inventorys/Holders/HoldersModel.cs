using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HolderInventoryModel")]
public class HoldersModel : ScriptableObject, IModel
{
    internal PlayerDataController data;
    internal ChestOpenController<ChestOpenView, ChestOpenModel> chestOpenController;
    internal GameObject CurrentCard;

    [SerializeField] internal GameObject cardPrefab;
}
