namespace AtomicTorch.CBND.CoreMod.CraftRecipes.MineralProcessingPlant
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Manufacturers;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeCrushedPragmium : Recipe.RecipeForManufacturing
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectMineralProcessingPlant>();

            duration = CraftingDuration.Long;

            inputItems.Add<ItemOrePragmium>(count: 1);

            outputItems.Add<ItemCrushedPragmium>(count: 3);
        }
    }
}