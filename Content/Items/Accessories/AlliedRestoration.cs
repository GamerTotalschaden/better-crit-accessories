using BetterCritAccessories.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class AlliedRestoration : MutexModItem
    {
        public static readonly float SUMMON_DAMAGE_INCREASE_PERCENT = 15;
        public static readonly float SUMMON_CRIT_CHANCE_INCREASE_PERCENT = 10;
        public static readonly float SUMMON_HEAL_PERCENTAGE_OF_DAMAGE = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(
            SUMMON_DAMAGE_INCREASE_PERCENT, SUMMON_CRIT_CHANCE_INCREASE_PERCENT, SUMMON_HEAL_PERCENTAGE_OF_DAMAGE
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
            player.GetDamage(DamageClass.Summon) += SUMMON_DAMAGE_INCREASE_PERCENT / 100;
            player.GetModPlayer<MinionCritPlayer>().CRIT_CHANCE_PERCENT += SUMMON_CRIT_CHANCE_INCREASE_PERCENT;
            player.GetModPlayer<HealOnCritPlayer>().AddCritHeal(DamageClass.Summon, SUMMON_HEAL_PERCENTAGE_OF_DAMAGE);
            player.GetModPlayer<NoLifeRegenPlayer>().NoLifeRegen = true; // life regen is 0
            player.aggro -= 400; // enemies are less likely to target you
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<AllyEmblem>();
            recipe.AddIngredient<RestoringNature>();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
