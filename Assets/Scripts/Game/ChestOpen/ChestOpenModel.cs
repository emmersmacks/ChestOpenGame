using UnityEngine;

[CreateAssetMenu(fileName = "ChestOpenModel")]
public class ChestOpenModel : ScriptableObject, IModel
{
    internal PlayerDataController data;
    internal CardController cardController;
    internal ChestInfo currentChest;
    [SerializeField] internal GameObject cardPref;
    [SerializeField] internal GameObject winCombinationPref;
    [SerializeField] internal ChestInfo defaultChest;
    [SerializeField] internal ChestInfo upgradeChest;
}
