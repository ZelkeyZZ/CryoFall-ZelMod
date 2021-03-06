namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairWoodArmor : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairStation>();

            duration = CraftingDuration.Medium;

            inputItems.Add<ItemWoodArmor>();
            inputItems.Add<ItemPlanks>(count: 37);
            inputItems.Add<ItemThread>(count: 5);
            inputItems.Add<ItemFibers>(count: 5);
            inputItems.Add<ItemBones>(count: 1);
            inputItems.Add<ItemSulfurPowder>(count: 5);
            inputItems.Add<ItemBottleWater>(count: 1);

            outputItems.Add<ItemWoodArmor>();
        }
    }
}