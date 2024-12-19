using BetterCritAccessories.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class CriticalMastery : ModItem
    {

        public static readonly float CRIT_CHANCE_INCREASE_PERCENT = 20;
        public static readonly float CRIT_DAMAGE_DECREASE_PERCENT = 20;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CRIT_CHANCE_INCREASE_PERCENT, CRIT_DAMAGE_DECREASE_PERCENT);

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Green;

            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Generic) += CRIT_CHANCE_INCREASE_PERCENT;
            player.GetModPlayer<ModifiedCritDamagePlayer>().ModifiedCritDamagePercent -= CRIT_DAMAGE_DECREASE_PERCENT;
        }
    }
}
