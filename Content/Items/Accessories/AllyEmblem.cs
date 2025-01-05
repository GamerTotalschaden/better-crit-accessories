using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class AllyEmblem : ModItem
    {
        public static readonly float SUMMON_DAMAGE_INCREASE_PERCENT = 15;
        public static readonly float SUMMON_CRIT_CHANCE_INCREASE_PERCENT = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(SUMMON_DAMAGE_INCREASE_PERCENT, SUMMON_CRIT_CHANCE_INCREASE_PERCENT);

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.LightRed;

            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += SUMMON_DAMAGE_INCREASE_PERCENT / 100;
            player.GetCritChance(DamageClass.Summon) += SUMMON_CRIT_CHANCE_INCREASE_PERCENT;
            player.aggro -= 400; // enemies are less likely to target you, same as Putrid Scent
        }

        public override void AddRecipes()
        {
            // crafted with 1 Summoner Emblem and 1 Putrid Scent at Tinkerer's Workshop
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SummonerEmblem);
            recipe.AddIngredient(ItemID.PutridScent);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
