namespace AtomicTorch.CBND.CoreMod.Items.Equipment.ApexArmor
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Characters;
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.CoreMod.ClientComponents.Input;
    using AtomicTorch.CBND.CoreMod.ClientComponents.PostEffects.NightVision;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.CoreMod.Stats;
    using AtomicTorch.CBND.CoreMod.Systems.TimeOfDaySystem;
    using AtomicTorch.CBND.CoreMod.UI.Controls.Menu.Options.Data;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Items;
    using AtomicTorch.CBND.GameApi.Data.State;
    using AtomicTorch.CBND.GameApi.Scripting;
    using AtomicTorch.CBND.GameApi.Scripting.ClientComponents;
    using AtomicTorch.CBND.GameApi.ServicesClient.Components;

    public class ItemApexSuit
        : ProtoItemEquipmentFullBody
          <ItemWithDurabilityPrivateState,
              EmptyPublicState,
              ItemApexSuit.ClientState>,
          IProtoItemEquipmentHeadWithLight
    {
        public override string Description =>
            "The peek of defense. What more do you need.";

        public override uint DurabilityMax => 1500;

        public override bool IsHairVisible => false;

        // TODO: there is an issue with long beard, add sprite mask clipping and restore this to true
        public override bool IsHeadVisible => false;

        public IReadOnlyItemFuelConfig ItemFuelConfig { get; }
            = new ItemFuelConfig();

        public IReadOnlyItemLightConfig ItemLightConfig { get; }
            = new ItemLightConfig() { IsLightEnabled = false };

        public override ObjectMaterial Material => ObjectMaterial.HardTissues;

        public override string Name => "Apex Armor";

        public bool ClientCanStartRefill(IItem item)
        {
            return false;
        }

        public override void ClientOnItemContainerSlotChanged(IItem item)
        {
            ClientAutoLightToggle(item);
        }

        public void ClientOnRefilled(IItem item, bool isCurrentHotbarItem)
        {
        }

        public override void ClientSetupSkeleton(
            IItem item,
            ICharacter character,
            IComponentSkeleton skeletonRenderer,
            List<IClientComponent> skeletonComponents,
            bool isPreview)
        {
            base.ClientSetupSkeleton(item,
                                     character,
                                     skeletonRenderer,
                                     skeletonComponents,
                                     isPreview);

            if (!isPreview
                && item.IsInitialized
                && (character?.IsCurrentClientCharacter ?? false))
            {
                ClientRefreshNightVisionState(item);
            }
        }

        public void ClientToggleLight(IItem item)
        {
            var character = item.Container.OwnerAsCharacter;
            if (character is null
                || !character.IsCurrentClientCharacter)
            {
                return;
            }

            Api.GetProtoEntity<ItemHelmetNightVisionAdvanced>()
               .SoundPresetItem
               .PlaySound(ItemSound.Use);

            var clientState = GetClientState(item);
            clientState.IsNightVisionActive = !clientState.IsNightVisionActive;

            ClientRefreshNightVisionState(item);
        }

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 1,
                kinetic: 1,
                explosion: 1,
                heat: 1,
                cold: 1,
                chemical: 1,
                radiation: 1,
                psi: 1);
        }

        protected override void PrepareEffects(Effects effects)
        {
            effects.AddPerk(this, StatName.PerkCannotBreakBones);

            // Dazed protection (-500%, dazed effect cannot be added).
            effects.AddPercent(this, StatName.DazedIncreaseRateMultiplier, -500);

            // 15% movement speed
            effects.AddPercent(this, StatName.MoveSpeed, 15);
        }

        private static void ClientAutoLightToggle(IItem item)
        {
            if (!item.IsInitialized)
            {
                return;
            }

            var character = item.Container.OwnerAsCharacter;
            var clientState = GetClientState(item);

            if (character is null
                || !character.IsCurrentClientCharacter
                || item.Container != character.SharedGetPlayerContainerEquipment())
            {
                clientState.IsNightVisionActive = false;
                return;
            }

            // the item is put into the player equipment container
            // enable the light automatically during the night
            var isLightRequired = TimeOfDaySystem.IsNight;

            if (clientState.IsNightVisionActive == isLightRequired)
            {
                return;
            }

            clientState.IsNightVisionActive = isLightRequired;
            // active state changed - invalidate skeleton renderer (so it will be rebuilt)
            character.ClientInvalidateSkeletonRenderer();

            if (clientState.IsNightVisionActive)
            {
                Api.GetProtoEntity<ItemHelmetNightVisionAdvanced>()
                   .SoundPresetItem
                   .PlaySound(ItemSound.Use);
            }
        }

        private static void ClientRefreshNightVisionState(IItem item)
        {
            if (!item.IsInitialized)
            {
                return;
            }

            var character = item.Container.OwnerAsCharacter;
            if (character is null
                || !character.IsCurrentClientCharacter)
            {
                return;
            }

            var clientState = GetClientState(item);
            var skeletonComponents = character.GetClientState<PlayerCharacterClientState>().SkeletonComponents;
            var component = skeletonComponents.Find(t => t is ClientComponentNightVisionEffect2);

            if (!clientState.IsNightVisionActive)
            {
                // turn effect off
                if (component is not null)
                {
                    component.Destroy();
                    skeletonComponents.Remove(component);
                }

                return;
            }

            // turn effect on
            if (component is not null)
            {
                return;
            }

            component = character.ClientSceneObject
                                 .AddComponent<ClientComponentNightVisionEffect2>();
            skeletonComponents.Add(component);
        }

        public class ClientState : BaseClientState
        {
            public bool IsNightVisionActive { get; set; }
        }

        protected override void PrepareHints(List<string> hints)
        {
            base.PrepareHints(hints);

            var key = ClientInputManager.GetKeyForButton(GameButton.HeadEquipmentLightToggle);
            hints.Add(string.Format(ItemHints.HelmetLightAndNightVision, InputKeyNameHelper.GetKeyText(key)));
        }
    }
}