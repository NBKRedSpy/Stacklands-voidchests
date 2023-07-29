using HarmonyLib;

namespace VoidChests
{
    class Plugin : Mod
    {
		public override void Ready()
        {
            Harmony.PatchAll();
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