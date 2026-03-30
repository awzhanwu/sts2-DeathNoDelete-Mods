using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;

namespace DeathNoDelete.scripts;

[ModInitializer("Init")]
public class Entry
{
    private static Harmony? _harmony;

    public static void Init()
    {
        _harmony = new Harmony("sts2.deathNoDelete");
        _harmony.PatchAll();
        Log.Info("DeathNoDelete Mod initialized!");
    }
}
