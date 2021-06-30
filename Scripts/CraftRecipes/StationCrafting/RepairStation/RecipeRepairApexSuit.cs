namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
	using AtomicTorch.CBND.CoreMod.Items.Equipment.ApexArmor;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.PragmiumArmor;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.SuperHeavyArmor;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairApexSuit : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;

        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairStation>();

            duration = CraftingDuration.Long;

            inputItems.Add<ItemApexSuit>();
			inputItems.Add<ItemPragmiumFiber>(count: 25);
            inputItems.Add<ItemIngotSteel>(count: 50);
            inputItems.Add<ItemKeinite>(count: 10);
            inputItems.Add<ItemComponentsHighTech>(count: 10);
            inputItems.Add<ItemBallisticPlate>(count: 10);

            outputItems.Add<ItemApexSuit>();
        }
    }
}