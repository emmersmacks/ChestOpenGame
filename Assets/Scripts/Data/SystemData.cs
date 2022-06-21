using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestGame.Data
{
    public class SystemData
    {
        public Action ReloadInventory = default;
        public Action ReloadPrizeFund = default;

        public int PrizeFund { get; set; } = 500;
    }
}

