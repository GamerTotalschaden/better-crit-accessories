using BetterCritAccessories.Common.Players;
using BetterCritAccessories.Content.Items.Consumables;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Buffs
{
    public class CritPotionBuff : ModBuff
    {
        public override LocalizedText Description => base.Description.WithFormatArgs(
            CritPotion.CRIT_CHANCE_INCREASE_PERCENT, CritPotion.CRIT_DAMAGE_INCREASE_PERCENT);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Generic) += CritPotion.CRIT_CHANCE_INCREASE_PERCENT;
            player.GetModPlayer<ModifiedCritDamagePlayer>().ModifiedCritDamagePercent += CritPotion.CRIT_DAMAGE_INCREASE_PERCENT;
        }
    }
}
