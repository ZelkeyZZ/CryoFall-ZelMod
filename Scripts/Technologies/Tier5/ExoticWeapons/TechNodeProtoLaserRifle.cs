namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.ExoticWeapons
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeProtoLaserRifle : TechNode<TechGroupExoticWeapons>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeProtoLaserRifle>()
				  .AddRecipe<RecipeRepairProtoLaserRifle>();
				  
			config.SetRequiredNode<TechNodeProtoSniperRifle>();
        }
    }
}