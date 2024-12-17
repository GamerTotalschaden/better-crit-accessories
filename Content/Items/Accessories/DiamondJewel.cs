using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class DiamondJewel : ModItem
    {

        public static readonly float CRIT_CHANCE_INCREASE_PERCENT = 5;

        // populate tooltip based on programmatically set values
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CRIT_CHANCE_INCREASE_PERCENT);

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;

            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Generic) += CRIT_CHANCE_INCREASE_PERCENT;
        }

        public override void AddRecipes()
        {
            // crafted with 5 diamonds at any anvil
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Diamond, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
