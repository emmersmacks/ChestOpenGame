using UnityEngine;

[CreateAssetMenu(fileName = "ChestOpenModel")]
public class ChestOpenModel : ScriptableObject, IModel
{
    internal PlayerDataController data;
    internal CardController cardController;
    internal ChestInfo currentChest;
}
