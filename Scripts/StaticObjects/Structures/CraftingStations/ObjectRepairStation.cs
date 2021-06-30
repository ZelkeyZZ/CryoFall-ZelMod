namespace AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations
{
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.CoreMod.Systems.Construction;
    using AtomicTorch.CBND.CoreMod.Systems.Physics;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.ServicesClient.Components;

    public class ObjectRepairStation : ProtoObjectCraftStation
    {
        public override string Description =>
            "A stationary workbench outfitted to repair armor and weapons.";

        public override string Name => "Repair Station";

        public override ObjectMaterial ObjectMaterial => ObjectMaterial.Wood;

        public override double ObstacleBlockDamageCoef => 0.5;

        public override float StructurePointsMax => 1200;

        protected override void ClientSetupRenderer(IComponentSpriteRenderer renderer)
        {
            base.ClientSetupRenderer(renderer);
            renderer.DrawOrderOffsetY = 0.2;
            renderer.PositionOffset += (0, 0.02);
        }

        protected override void CreateLayout(StaticObjectLayout layout)
        {
            layout.Setup("##");
        }

        protected override void PrepareConstructionConfig(
            ConstructionTileRequirements tileRequirements,
            ConstructionStageConfig build,
            ConstructionStageConfig repair,
            ConstructionUpgradeConfig upgrade,
            out ProtoStructureCategory category)
        {
			tileRequirements.Clear()
                            .Add(ConstructionTileRequirements.DefaultForPlayerStructuresOwnedOrFreeLand);
			
            category = GetCategory<StructureCategoryIndustry>();

            build.StagesCount = 5;
            build.StageDurationSeconds = BuildDuration.Short;
            build.AddStageRequiredItem<ItemPlanks>(count: 5);

            repair.StagesCount = 10;
            repair.StageDurationSeconds = BuildDuration.Short;
            repair.AddStageRequiredItem<ItemPlanks>(count: 1);
        }

        protected override void SharedCreatePhysics(CreatePhysicsData data)
        {
            data.PhysicsBody
                .AddShapeRectangle((1.83, 0.75), offset: (0.1, 0.1))
                .AddShapeRectangle((1.8, 0.8),   offset: (0.1, 0.2), group: CollisionGroups.HitboxMelee)
				.AddShapeRectangle((1.6, 0.2), offset: (0.2, 0.85), group: CollisionGroups.HitboxRanged)
                .AddShapeRectangle((2, 1.2),     offset: (0, 0),     group: CollisionGroups.ClickArea);
        }
    }
}