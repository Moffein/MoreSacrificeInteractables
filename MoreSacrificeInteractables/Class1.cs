using BepInEx;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MoreSacrificeInteractables
{
    [BepInPlugin("com.Moffein.MoreSacrificeInteractables", "MoreSacrificeInteractables", "1.0.0")]
    public class PrintToInventory : BaseUnityPlugin
    {
        public static bool allowEquipBarrel, allowEquipShop, allowLunarPod, allowVoidCradle, allowVoidTriple;
        public static float equipBarrelWeight, equipShopWeight, lunarPodWeight, voidCradleWeight, voidTripleWeight;

        public void Awake()
        {
            allowEquipBarrel = Config.Bind("Equipment", "Equipment Barrel", true, "Allow this interactable to spawn when Sacrifice is enabled.").Value;
            equipBarrelWeight = Config.Bind("Equipment", "Equipment Barrel Weight", 0.25f, "Affects how often this interactable will spawn when Sacrifice is enabled.").Value;

            allowEquipShop = Config.Bind("Equipment", "Equipment Multishop", true, "Allow this interactable to spawn when Sacrifice is enabled.").Value;
            equipShopWeight = Config.Bind("Equipment", "Equipment Multishop Weight", 0.25f, "Affects how often this interactable will spawn when Sacrifice is enabled.").Value;

            allowLunarPod = Config.Bind("Lunar", "Lunar Pod", true, "Allow this interactable to spawn when Sacrifice is enabled.").Value;
            lunarPodWeight = Config.Bind("Lunar", "Lunar Pod Weight", 0.5f, "Affects how often this interactable will spawn when Sacrifice is enabled.").Value;

            allowVoidCradle = Config.Bind("Void", "Void Cradle", true, "Allow this interactable to spawn when Sacrifice is enabled.").Value;
            voidCradleWeight = Config.Bind("Void", "Void Cradle Weight", 1f, "Affects how often this interactable will spawn when Sacrifice is enabled.").Value;

            allowVoidTriple = Config.Bind("Void", "Void Multishop", true, "Allow this interactable to spawn when Sacrifice is enabled.").Value;
            voidTripleWeight = Config.Bind("Void", "Void Multishop Weight", 1f, "Affects how often this interactable will spawn when Sacrifice is enabled.").Value;

            if (allowEquipBarrel) SetSacrificeAllowed("RoR2/Base/EquipmentBarrel/iscEquipmentBarrel.asset", equipBarrelWeight);
            if (allowEquipShop) SetSacrificeAllowed("RoR2/Base/TripleShopEquipment/iscTripleShopEquipment.asset", equipShopWeight);
            if (allowLunarPod) SetSacrificeAllowed("RoR2/Base/LunarChest/iscLunarChest.asset", lunarPodWeight);
            if (allowVoidCradle) SetSacrificeAllowed("RoR2/DLC1/VoidChest/iscVoidChest.asset", voidCradleWeight);
            if (allowVoidTriple) SetSacrificeAllowed("RoR2/DLC1/VoidTriple/iscVoidTriple.asset", voidTripleWeight);
        }
        
        private void SetSacrificeAllowed(string addressablePath, float mult = 1f)
        {
            InteractableSpawnCard isc = Addressables.LoadAssetAsync<InteractableSpawnCard>(addressablePath).WaitForCompletion();
            if (isc)
            {
                isc.skipSpawnWhenSacrificeArtifactEnabled = false;
                isc.weightScalarWhenSacrificeArtifactEnabled *= mult;
            }
        }
    }
}
