﻿using BepInEx;
using MTDUI.HarmonyPatches;

namespace MTDUI
{
    [BepInPlugin("dev.bobbie.20mtd.mtdui", "MTDUI", "1.0.3")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake() {
            MTDUIPatches.ApplyHarmonyPatches();
        }
    }
}
