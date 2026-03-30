using HarmonyLib;
using MegaCrit.Sts2.Core.Runs.Metrics;
using MegaCrit.Sts2.Core.Saves.Managers;
using MegaCrit.Sts2.Core.Saves;

namespace DeathNoDelete.scripts.patches;

[HarmonyPatch(typeof(RunSaveManager), "DeleteCurrentRun")]
class Patch_DeleteCurrentRun
{
    [HarmonyPatch("DeleteCurrentRun")]
    static bool Prefix()
    {
        return DataRecord.canDelete;
    }
}

class DeleteCurrentMultiplayerRun
{
    [HarmonyPatch(typeof(RunSaveManager), "DeleteCurrentMultiplayerRun")]
    static bool Prefix()
    {
        return DataRecord.canDelete;
    }
}

[HarmonyPatch(typeof(RunHistorySaveManager), "SaveHistory")]
class Patch_SaveHistory
{
    static bool Prefix()
    {
        return DataRecord.canDelete;
    }
}

[HarmonyPatch(typeof(MetricUtilities))]
class Patch_UploadRunMetrics
{
    [HarmonyPatch(typeof(MetricUtilities), "UploadRunMetrics", [typeof(SerializableRun), typeof(bool), typeof(ulong)])]
    static bool Prefix()
    {
        return DataRecord.canDelete;
    }
}

class Patch_UploadSettingsMetric
{
    [HarmonyPatch(typeof(MetricUtilities), "UploadSettingsMetric")]
    static bool Prefix()
    {
        return DataRecord.canDelete;
    }
}