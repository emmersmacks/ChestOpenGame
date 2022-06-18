using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestGame.Game.View
{
    public class ChestOpenView : MonoBehaviour, IView
    {

        [SerializeField] internal Button HackButton;
        [SerializeField] internal Button OpenButton;
        [SerializeField] internal Button CloseButton;
        [SerializeField] internal Button UpgradeButton;
        [SerializeField] internal Image Preview;
        [SerializeField] internal CardsShowView CardShowView;
        [SerializeField] internal GameObject OpenChestEffect;
        [SerializeField] internal GameObject Buttons;
        [SerializeField] internal AudioSource OpenChestAudio;
        [SerializeField] internal AudioSource ButtonAudio;
        [SerializeField] internal GameObject SlotPref;
        [SerializeField] internal AudioSource MisteryBoxAudio;

        public InventoryChestSlotView InstantiateSlotCopy(InventoryChestSlotView viewSlot)
        {
            var newSlot = Instantiate(SlotPref, viewSlot.transform.position, Quaternion.identity, transform);
            var newSlotView = newSlot.GetComponent<InventoryChestSlotView>();
            return newSlotView;
        }

        public void DestroySlotCopy(InventoryChestSlotView viewSlot)
        {
            Destroy(viewSlot.gameObject);
        }
    }
}

