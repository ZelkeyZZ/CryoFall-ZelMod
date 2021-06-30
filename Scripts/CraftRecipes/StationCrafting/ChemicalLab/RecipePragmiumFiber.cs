namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipePragmiumFiber : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
           StationsList stations,
           out TimeSpan duration,
           InputItems inputItems,
           OutputItems outputItems)
        {
            stations.Add<ObjectChemicalLab>();

            duration = CraftingDuration.Long;

            inputItems.Add<ItemCrushedPragmium>(count: 10);
            inputItems.Add<ItemSolvent>(count: 10);
			inputItems.Add<ItemFibers>(count: 50);
			
            outputItems.Add<ItemPragmiumFiber>(count: 20);
        }
    }
}