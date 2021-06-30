namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Ammo;
    using AtomicTorch.CBND.CoreMod.Skills;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Weapons;

    public class ItemProtoSniperRifle : ProtoItemWeaponRanged
    {
        public override ushort AmmoCapacity => 15;

        public override double AmmoReloadDuration => 1;

        public override double CharacterAnimationAimingRecoilDuration => 0;

        public override double CharacterAnimationAimingRecoilPower => 0;

        public override double DamageMultiplier => 2.5; // higher damage

        public override string Description => "A more Powerful Version of Sniper Rifle that uses .300 rounds.";

        public override uint DurabilityMax => 3500;

        public override double FireInterval => 1 / 2d; // slower firing rate

        public override string Name => "Proto Heavy Sniper Rifle";

        public override double RangeMultiplier => 2; // significantly higher range

        public override double SpecialEffectProbability => 1;

        protected override ProtoSkillWeapons WeaponSkill => GetSkill<SkillWeaponsConventional>();

        protected override WeaponFireTracePreset PrepareFireTracePreset()
        {
            return WeaponFireTracePresets.HeavySniper;
        }

        protected override void PrepareMuzzleFlashDescription(MuzzleFlashDescription description)
        {
            description.Set(MuzzleFlashPresets.ModernRifle)
                       .Set(textureScreenOffset: (62, 5));
        }

        protected override void PrepareProtoWeaponRanged(
            out IEnumerable<IProtoItemAmmo> compatibleAmmoProtos,
            ref DamageDescription overrideDamageDescription)
        {
            compatibleAmmoProtos = GetAmmoOfType<IAmmoCaliber300>();
        }

        protected override ReadOnlySoundPreset<WeaponSound> PrepareSoundPresetWeapon()
        {
            return BruhSound.WeaponRangedProtoSniperRifle;
        }

        protected override void ServerOnSpecialEffect(ICharacter damagedCharacter, double damage)
        {
            ServerWeaponSpecialEffectsHelper.OnFirearmHit(damagedCharacter, damage);
        }
    }
}