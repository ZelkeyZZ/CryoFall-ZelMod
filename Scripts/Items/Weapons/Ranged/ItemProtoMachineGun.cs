namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Ammo;
    using AtomicTorch.CBND.CoreMod.Skills;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Weapons;

    public class ItemProtoMachineGun : ProtoItemWeaponRanged
    {
        public override ushort AmmoCapacity => 30;

        public override double AmmoReloadDuration => 1;

        public override double CharacterAnimationAimingRecoilDuration => 0.0;

        public override double CharacterAnimationAimingRecoilPower => 0.0;

        public override double CharacterAnimationAimingRecoilPowerAddCoef
            => 0.0; // full recoil power will be gained on third shot

        public override double DamageMultiplier => 1.5; // slightly lower than default

        public override string Description => "A more Powerful Version of Machine Gun that uses .300 rounds.";

        public override uint DurabilityMax => 3500;

        public override double FireInterval => 1 / 10d; // 8 per second

        public override double RangeMultiplier => 1.3;

        public override string Name => "Proto Heavy Machine Gun";

        public override double SpecialEffectProbability => 1;
		
		public override float ShotVolumeMultiplier => 1.25f;

        protected override ProtoSkillWeapons WeaponSkill => GetSkill<SkillWeaponsConventional>();

        protected override WeaponFirePatternPreset PrepareFirePatternPreset()
        {
            return new(
                initialSequence: new[] { 0.0, 1.0, 2.0 },
                cycledSequence: new[] { 1.5, 4.0, 3.0, 1.0, 4.5 });
        }

        protected override void PrepareMuzzleFlashDescription(MuzzleFlashDescription description)
        {
            description.Set(MuzzleFlashPresets.ModernSubmachinegun)
                       .Set(textureScreenOffset: (27, 7));
        }

        protected override void PrepareProtoWeaponRanged(
            out IEnumerable<IProtoItemAmmo> compatibleAmmoProtos,
            ref DamageDescription overrideDamageDescription)
        {
            compatibleAmmoProtos = GetAmmoOfType<IAmmoCaliber300>();
        }

        protected override ReadOnlySoundPreset<WeaponSound> PrepareSoundPresetWeapon()
        {
            return BruhSound.WeaponRangedProtoMachineGun;
        }

        protected override void ServerOnSpecialEffect(ICharacter damagedCharacter, double damage)
        {
            ServerWeaponSpecialEffectsHelper.OnFirearmHit(damagedCharacter, damage);
        }
    }
}