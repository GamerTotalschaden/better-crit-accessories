using BetterCritAccessories.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class ArcaneRestoration : ModItem
    {
        public static readonly float MAGIC_CRIT_CHANCE_INCREASE_PERCENT = 10;
        public static readonly float HEAL_PERCENTAGE_OF_DAMAGE = 2.5f;
        public static readonly float MANA_CHANCE_PERCENT = 100;
        public static readonly float MANA_PERCENTAGE_OF_DAMAGE = 2.5f;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(
            MAGIC_CRIT_CHANCE_INCREASE_PERCENT,
            HEAL_PERCENTAGE_OF_DAMAGE,
            MANA_PERCENTAGE_OF_DAMAGE
        );

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
            player.GetCritChance(DamageClass.Magic) += MAGIC_CRIT_CHANCE_INCREASE_PERCENT;
            player.GetModPlayer<HealOnCritPlayer>().AddCritHeal(DamageClass.Magic, HEAL_PERCENTAGE_OF_DAMAGE);
            player.GetModPlayer<ManaOnCritPlayer>().ManaChancePercent += MANA_CHANCE_PERCENT;
            player.GetModPlayer<ManaOnCritPlayer>().ManaPercentageOfDamage += MANA_PERCENTAGE_OF_DAMAGE;
            player.manaFlower = true;
            player.aggro -= 400; // enemies are less likely to target you, same as Putrid Scent
            player.GetModPlayer<NoLifeRegenPlayer>().NoLifeRegen = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<RestoringNature>();
            recipe.AddIngredient(ItemID.ArcaneFlower);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
