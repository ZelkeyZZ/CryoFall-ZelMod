namespace AtomicTorch.CBND.CoreMod.Items.Implants
{
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Stats;

    public class ItemImplantPragmiumBones : ProtoItemEquipmentImplant
    {
        public override string Description =>
            "Transforms your bones into pragmium. Giving numerous superhuman abilities.";

        public override string Name => "Pragmiumskeletal Implant";

        protected override void PrepareEffects(Effects effects)
        {
            base.PrepareEffects(effects);

            effects.AddPercent(this, StatName.DazedIncreaseRateMultiplier, -500);

            effects.AddValue(this, StatName.PerkCannotBreakBones, 1);
			
			var protection = 0.5;
            effects.AddValue(this, StatName.DefenseImpact, protection)
                   .AddValue(this, StatName.DefenseKinetic,   protection)
                   .AddValue(this, StatName.DefenseExplosion, protection)
                   .AddValue(this, StatName.DefenseHeat,      protection)
                   .AddValue(this, StatName.DefenseCold,      protection)
                   .AddValue(this, StatName.DefenseChemical,  protection)
                   .AddValue(this, StatName.DefenseRadiation, protection)
                   .AddValue(this, StatName.DefensePsi, protection);
				   
			effects.AddPercent(this, StatName.HealthRegenerationPerSecond, 1000);
			
			effects.AddPerk(this, StatName.PerkEatSpoiledFood);
			
			effects.AddPerk(this, StatName.PerkOvereatWithoutConsequences);
			
			effects.AddPercent(this, StatName.MedicineToxicityMultiplier, -200);
			
			effects.AddPercent(this, StatName.ToxinsIncreaseRateMultiplier, -200);
			
			effects.AddPercent(this, StatName.HungerRate, -100);

            effects.AddPercent(this, StatName.ThirstRate, -100);
			
			effects.AddValue(this, StatName.EnergyChargeRegenerationPerMinute, 75);
        }
    }
}