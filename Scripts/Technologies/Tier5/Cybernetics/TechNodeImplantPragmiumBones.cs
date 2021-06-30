namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.Cybernetics
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeImplantReinforcedBones : TechNode<TechGroupCyberneticsT5>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeImplantPragmiumBones>();
				  
        }
    }
}