﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairCrossbow : Recipe.RecipeForStationCrafting
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

            inputItems.Add<ItemIngotIron>(count: 1);
			inputItems.Add<ItemFibers>(count: 15);
			inputItems.Add<ItemPlanks>(count: 25);
            inputItems.Add<ItemCrossbow>(count: 1);

            outputItems.Add<ItemCrossbow>();
        }
    }
}