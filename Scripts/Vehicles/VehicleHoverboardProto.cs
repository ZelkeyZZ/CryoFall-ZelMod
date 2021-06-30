namespace AtomicTorch.CBND.CoreMod.Vehicles
{
    using System.Windows.Media;
    using AtomicTorch.CBND.CoreMod.ClientComponents.Rendering.Lighting;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.Extensions;
    using AtomicTorch.CBND.GameApi.Resources;
    using AtomicTorch.GameEngine.Common.Primitives;

    public class VehicleHoverboardProto : ProtoVehicleHoverboard
    {
        public override string Description =>
            "Advance Version of Hoverboard Mk2. Basically much faster and energy efficient.";

        public override ushort EnergyUsePerSecondIdle => 5;

        public override ushort EnergyUsePerSecondMoving => 25;

        public override Color LightColor => LightColors.Flashlight.WithAlpha(0x88);

        public override Size2F LightLogicalSize => 15;

        public override Vector2D LightPositionOffset => (0, 5);

        public override Size2F LightSize => 8;

        public override string Name => "Hoverboard Proto";

        public override double PhysicsBodyAccelerationCoef => 4;

        public override double PhysicsBodyFriction => 8;

        public override double StatMoveSpeed => 7.0;

        public override float StructurePointsMax => 500;

        public override TextureResource TextureResourceHoverboard { get; }
            = new("Vehicles/HoverboardProto");

        public override TextureResource TextureResourceHoverboardLight { get; }
            = new("Vehicles/HoverboardProtoLight");

        public override double VehicleWorldHeight => 1;

        protected override SoundResource EngineSoundResource { get; }
            = new("Objects/Vehicles/Hoverboard/Engine3");

        protected override double EngineSoundVolume => 0.2;

        public override Vector2D SharedGetObjectCenterWorldOffset(IWorldObject worldObject)
        {
            return (0, -0.3);
        }

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(ObjectDefensePresets.Tier2);
        }

        protected override void PrepareProtoVehicle(
            InputItems buildRequiredItems,
            InputItems repairStageRequiredItems,
            out int repairStagesCount)
        {
            buildRequiredItems
                .Add<ItemStructuralPlating>(10)
                .Add<ItemPragmiumHeart>(5)
                .Add<ItemComponentsHighTech>(10);

            repairStageRequiredItems
                .Add<ItemIngotSteel>(50);

            repairStagesCount = 1;
        }
    }
}