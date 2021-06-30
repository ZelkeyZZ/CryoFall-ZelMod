namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeProtoLaserRifle : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectWeaponWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemLaserRifle>();
            inputItems.Add<ItemPragmiumFiber>(count: 5);
            inputItems.Add<ItemComponentsOptical>(count: 40);
            inputItems.Add<ItemComponentsHighTech>(count: 20);
            inputItems.Add<ItemPowerCell>(count: 2);

            outputItems.Add<ItemProtoLaserRifle>();
        }
    }
}