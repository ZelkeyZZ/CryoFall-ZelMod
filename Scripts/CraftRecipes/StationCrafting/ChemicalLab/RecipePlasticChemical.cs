namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
	using AtomicTorch.CBND.CoreMod.Items;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipePlasticChemical : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
           StationsList stations,
           out TimeSpan duration,
           InputItems inputItems,
           OutputItems outputItems)
        {
            stations.Add<ObjectChemicalLab>();

            duration = CraftingDuration.Short;

            inputItems.Add<ItemRubberVulcanized>(count: 10);
            inputItems.Add<ItemComponentsIndustrialChemicals>(count: 5);
			
            outputItems.Add<ItemPlastic>(count: 20);
			
			this.Icon = ClientItemIconHelper.CreateComposedIcon(
                name: this.Id + "Icon",
                primaryIcon: GetItem<ItemPlastic>().Icon,
                secondaryIcon: GetItem<ItemComponentsIndustrialChemicals>().Icon);
        }
    }
}