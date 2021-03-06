namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Debuffs;
    using AtomicTorch.CBND.CoreMod.Items.Ammo;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.CoreMod.Systems.Weapons;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Weapons;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.Resources;
    using AtomicTorch.CBND.GameApi.ServicesClient.Rendering;
    using AtomicTorch.GameEngine.Common.Helpers;
    using AtomicTorch.GameEngine.Common.Primitives;

    public class ItemProtoLaserRifle : ProtoItemWeaponRangedEnergyZ
    {
        private static readonly TextureResource TextureResourceBeam
            = new("FX/WeaponTraces/BruhBeam.png");

        public override double CharacterAnimationAimingRecoilDuration => 0.0;

        public override double CharacterAnimationAimingRecoilPower => 0.0;

        public override double DamageToMinerals => 200;

        public override double DamageToTree => 200;

        public override string Description =>
            "A more Powerful Version of Laser Rifle, however it's only Effective Against Trees And Ores.";

        public override uint DurabilityMax => 3500;

        public override double DamageMultiplier => 0;

        public override double EnergyUsePerShot => 10;

        public override double FireInterval => 1 / 10d;

        public override string Name => "Proto Laser Rifle";

        public override float ShotVolumeMultiplier => 2.25f;

        public override double SpecialEffectProbability => 1;

        public override void ClientOnWeaponHitOrTrace(
            ICharacter firingCharacter,
            Vector2D worldPositionSource,
            IProtoItemWeapon protoWeapon,
            IProtoItemAmmo protoAmmo,
            IProtoCharacter protoCharacter,
            in Vector2Ushort fallbackCharacterPosition,
            IReadOnlyList<WeaponHitData> hitObjects,
            in Vector2D endPosition,
            bool endsWithHit)
        {
            ComponentWeaponEnergyBeam.Create(
                sourcePosition: worldPositionSource,
                targetPosition: endPosition,
                traceStartWorldOffset: 0.1,
                texture: TextureResourceBeam,
                beamWidth: 0.15,
                originOffset: Vector2D.Zero,
                duration: 0.1333,
                endsWithHit,
                fadeInDistance: 0.25,
                fadeOutDistanceHit: 0,
                fadeOutDistanceNoHit: 0.5,
                blendMode: BlendMode.AlphaBlendPremultiplied);
        }

        public override void SharedOnHit(
            WeaponFinalCache weaponCache,
            IWorldObject damagedObject,
            double damage,
            WeaponHitData hitData,
            out bool isDamageStop)
        {
            base.SharedOnHit(weaponCache, damagedObject, damage, hitData, out isDamageStop);

            if (damage < 1)
            {
                return;
            }

            if (IsServer
                && damagedObject is ICharacter damagedCharacter
                && RandomHelper.RollWithProbability(0.25))
            {
                damagedCharacter.ServerAddStatusEffect<StatusEffectDazed>(
                    // add 2 seconds of dazed effect
                    intensity: 2 / StatusEffectDazed.MaxDuration);
            }
        }

        protected override void ClientInitialize(ClientInitializeData data)
        {
            base.ClientInitialize(data);
            ComponentWeaponEnergyBeam.PreloadAssets();
            Client.Rendering.PreloadTextureAsync(TextureResourceBeam);
        }

        protected override WeaponFireTracePreset PrepareFireTracePreset()
        {
            // see ClientOnWeaponHitOrTrace for the custom laser ray implementation
            return WeaponFireTracePresets.LaserBeamRed;
        }

        protected override void PrepareMuzzleFlashDescription(MuzzleFlashDescription description)
        {
            description.Set(MuzzleFlashPresets.EnergyLaserWeaponRedLarge)
                       .Set(textureScreenOffset: (3, 2));
        }

        protected override void PrepareProtoWeaponRangedEnergy(
            ref DamageDescription damageDescription)
        {
            damageDescription = new DamageDescription(
                damageValue: 1,
                armorPiercingCoef: 1,
                finalDamageMultiplier: 1.1,
                rangeMax: 20,
                damageDistribution: new DamageDistribution(DamageType.Heat, 1));
        }

        protected override ReadOnlySoundPreset<WeaponSound> PrepareSoundPresetWeapon()
        {
            return BruhSound.WeaponRangedProtoLaserRifle;
        }

        protected override void ServerOnSpecialEffect(ICharacter damagedCharacter, double damage)
        {
            ServerWeaponSpecialEffectsHelper.OnLaserHit(damagedCharacter, damage);
            // also, see SharedOnHit as it adds Dazed
        }
    }
}