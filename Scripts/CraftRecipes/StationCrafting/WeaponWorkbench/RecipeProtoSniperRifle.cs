namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeProtoSniperRifle : Recipe.RecipeForStationCrafting
    {
		protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectWeaponWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemRifle300>();
            inputItems.Add<ItemPragmiumFiber>(count: 5);
            inputItems.Add<ItemComponentsOptical>(count: 50);
            inputItems.Add<ItemComponentsWeapon>(count: 50);

            outputItems.Add<ItemProtoSniperRifle>();
        }
    }
}