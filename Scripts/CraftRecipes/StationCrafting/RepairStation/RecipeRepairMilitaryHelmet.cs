namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
	using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairMilitaryHelmet : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;

        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairStation>();

            duration = CraftingDuration.Medium;
			
			//Initial Item Cost.
			inputItems.Add<ItemMilitaryHelmet>();

            inputItems.Add<ItemIngotSteel>(count: 10);
            inputItems.Add<ItemThread>(count: 12);
            inputItems.Add<ItemTarpaulin>(count: 10);
			//One and One Half Glue Cost.
			inputItems.Add<ItemBones>(3);
			inputItems.Add<ItemSulfurPowder>(count: 7);
			inputItems.Add<ItemBottleWater>();

            outputItems.Add<ItemMilitaryHelmet>();
			outputItems.Add<ItemBottleEmpty>();
        }
    }
}