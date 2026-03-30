using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens.MainMenu;
using MegaCrit.Sts2.Core.Runs;

namespace DeathNoDelete.scripts.patches;

[HarmonyPatch(typeof(RunManager), "OnEnded")]
class Patch_OnEnded
{
    static void Prefix(bool isVictory, RunManager __instance)
    {
        DataRecord.canDelete = isVictory || __instance.IsAbandoned;
    }
}

[HarmonyPatch(typeof(NMainMenu), "AbandonRun")]
class Patch_AbandonRun
{
    static void Prefix()
    {
        DataRecord.canDelete = true;
    }
}
