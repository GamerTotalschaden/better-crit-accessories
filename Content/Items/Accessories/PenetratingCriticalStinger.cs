using BetterCritAccessories.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class PenetratingCriticalStinger : ModItem
    {
        public static readonly float ARMOR_PEN_INCREASE = 7;
        public static readonly float CRIT_CHANCE_INCREASE_PERCENT = 10;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ARMOR_PEN_INCREASE, CRIT_CHANCE_INCREASE_PERCENT);

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Pink;

            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetArmorPenetration(DamageClass.Generic) += ARMOR_PEN_INCREASE;
            player.GetModPlayer<BeesStingerOnCritPlayer>().Active = true;
            player.GetCritChance(DamageClass.Generic) += CRIT_CHANCE_INCREASE_PERCENT;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<CriticalStinger>();
            recipe.AddIngredient(ItemID.EyeoftheGolem);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
