namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.Industry
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes.MineralProcessingPlant;

    public class TechNodeCrushedPragmium : TechNode<TechGroupIndustryT5>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeCrushedPragmium>();
        }
    }
}