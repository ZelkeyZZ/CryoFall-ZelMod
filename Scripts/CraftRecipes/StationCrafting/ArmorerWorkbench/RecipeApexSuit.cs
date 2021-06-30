namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.ApexArmor;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.PragmiumArmor;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.SuperHeavyArmor;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeApexSuit : Recipe.RecipeForStationCrafting
    {

       protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectArmorerWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemPragmiumSuit>();
            inputItems.Add<ItemSuperHeavySuit>();
            inputItems.Add<ItemPragmiumFiber>(count: 50);
            inputItems.Add<ItemIngotSteel>(count: 150);
            inputItems.Add<ItemKeinite>(count: 20);
            inputItems.Add<ItemComponentsHighTech>(count: 20);
            inputItems.Add<ItemBallisticPlate>(count: 20);

            outputItems.Add<ItemApexSuit>();
        }
    }
}