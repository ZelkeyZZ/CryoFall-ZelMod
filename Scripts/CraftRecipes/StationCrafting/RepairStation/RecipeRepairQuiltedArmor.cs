﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.Quilted;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
	using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairQuiltedArmor : Recipe.RecipeForStationCrafting
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
			inputItems.Add<ItemQuiltedArmor>();

            inputItems.Add<ItemThread>(count: 12);
            inputItems.Add<ItemRope>(count: 2);
			inputItems.Add<ItemFibers>(count: 5);
			//Half Glue Cost.
			inputItems.Add<ItemBones>();
			inputItems.Add<ItemSulfurPowder>(count: 5);
			inputItems.Add<ItemBottleWater>();
			
            outputItems.Add<ItemQuiltedArmor>();
			outputItems.Add<ItemBottleEmpty>();
        }
    }
}