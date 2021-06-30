namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.Cybernetics
{
    using AtomicTorch.CBND.CoreMod.Technologies.Tier5.Chemistry;
    using AtomicTorch.CBND.CoreMod.Technologies.Tier4.Cybernetics;

    public class TechGroupCyberneticsT5 : TechGroup
    {
        public override string Description => TechGroupsLocalization.CyberneticsDescription;

        public override string Name => TechGroupsLocalization.CyberneticsName;

        public override TechTier Tier => TechTier.Tier5;

        protected override void PrepareTechGroup(Requirements requirements)
        {
            requirements.AddGroup<TechGroupChemistryT5>(completion: 1);
            requirements.AddGroup<TechGroupCyberneticsT4>(completion: 1);
        }
    }
}