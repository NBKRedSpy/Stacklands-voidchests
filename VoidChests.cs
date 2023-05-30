using BepInEx;
using HarmonyLib;

namespace VoidChests
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);
        private void Awake()
        {
            harmony.PatchAll();

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }

    [HarmonyPatch(typeof(ResourceChest), nameof(ResourceChest.UpdateCard))]
    public class ResourceChestPatch
    {
        public static void Postfix(ResourceChest __instance)
        {
            if (__instance.ResourceCount == __instance.MaxResourceCount)
            {
                __instance.ResourceCount--;
            }
        }
    }
}