namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.ExoticWeapons
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeProtoMachineGun : TechNode<TechGroupExoticWeapons>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeProtoMachineGun>()
				  .AddRecipe<RecipeRepairProtoMachineGun>();
        }
    }
}