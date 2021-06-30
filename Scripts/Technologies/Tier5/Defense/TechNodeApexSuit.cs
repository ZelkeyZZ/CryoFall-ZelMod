namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeApexSuit : TechNode<TechGroupDefenseT5>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeApexSuit>()
				  .AddRecipe<RecipeRepairApexSuit>();

            config.SetRequiredNode<TechNodeSuperHeavySuit>();
        }
    }
}