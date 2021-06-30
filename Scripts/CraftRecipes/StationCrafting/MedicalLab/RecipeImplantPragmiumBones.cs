namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Implants;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeImplantPragmiumBones : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectMedicalLab>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemComponentsPharmaceutical>(count: 200);
            inputItems.Add<ItemKeinite>(count: 50);
            inputItems.Add<ItemIngotSteel>(count: 50);
			inputItems.Add<ItemPragmiumFiber>(count: 50);
            inputItems.Add<ItemVialBiomaterial>(count: 50);

            outputItems.Add<ItemImplantPragmiumBones>();
        }
    }
}