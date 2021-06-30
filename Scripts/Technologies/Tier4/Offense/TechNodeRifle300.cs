namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.Offense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeRifle300 : TechNode<TechGroupOffenseT4>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeRifle300>()
                  .AddRecipe<RecipeRepairRifle300>();

            config.SetRequiredNode<TechNodeMachinegun300>();
        }
    }
}