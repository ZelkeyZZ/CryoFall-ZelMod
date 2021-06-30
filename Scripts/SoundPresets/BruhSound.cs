namespace AtomicTorch.CBND.CoreMod.SoundPresets
{
    using static WeaponSound;

    public static class BruhSound
    {
        public static readonly ReadOnlySoundPreset<WeaponSound> SpecialUseSkeletonSound
            = new SoundPreset<WeaponSound>();

        public static readonly ReadOnlySoundPreset<WeaponSound> WeaponRanged
            = new SoundPreset<WeaponSound>()
              .Add(Reload,         "Weapons/Ranged/Reload")
              .Add(ReloadFinished, "Weapons/Ranged/ReloadFinished")
              .Add(Empty,          "Weapons/Ranged/Empty");

        public static readonly ReadOnlySoundPreset<WeaponSound> WeaponRangedProtoLaserRifle
            = WeaponRanged.Clone()
                          .Replace(Shot, "Weapons/Ranged/ShotProtoLaserRifle");
						
		public static readonly ReadOnlySoundPreset<WeaponSound> WeaponRangedProtoMachineGun
            = WeaponRanged.Clone()
                          .Replace(Shot, "Weapons/Ranged/ShotProtoMachinegun");

        public static readonly ReadOnlySoundPreset<WeaponSound> WeaponRangedProtoSniperRifle
            = WeaponRanged.Clone()
                          .Replace(Shot, "Weapons/Ranged/ShotProtoSniperRifle");
    }
}