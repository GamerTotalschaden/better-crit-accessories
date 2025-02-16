using BetterCritAccessories.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class PreciseRestoration : ModItem
    {
        public static readonly float RANGED_DAMAGE_INCREASE_PERCENT = 15;
        public static readonly float RANGED_CRIT_CHANCE_INCREASE_PERCENT = 10;
        public static readonly float HEAL_CHANCE_PERCENT = 100;
        public static readonly float HEAL_PERCENTAGE_OF_DAMAGE = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(
            RANGED_DAMAGE_INCREASE_PERCENT, RANGED_CRIT_CHANCE_INCREASE_PERCENT, HEAL_PERCENTAGE_OF_DAMAGE);

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.LightPurple;

            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += RANGED_DAMAGE_INCREASE_PERCENT / 100;
            player.GetCritChance(DamageClass.Ranged) += RANGED_CRIT_CHANCE_INCREASE_PERCENT;
            player.GetModPlayer<HealOnCritPlayer>().HealChancePercent += HEAL_CHANCE_PERCENT;
            player.GetModPlayer<HealOnCritPlayer>().OnlyAffectedClass = DamageClass.Ranged;
            player.GetModPlayer<HealOnCritPlayer>().HealPercentageOfDamage += HEAL_PERCENTAGE_OF_DAMAGE;
            player.aggro -= 400; // enemies are less likely to target you, same as Putrid Scent
            player.GetModPlayer<NoLifeRegenPlayer>().NoLifeRegen = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<RestoringNature>();
            recipe.AddIngredient<SmellyEmblem>();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
