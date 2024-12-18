using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class SmellyEmblem : ModItem
    {
        public static readonly float RANGED_DAMAGE_INCREASE_PERCENT = 15;
        public static readonly float RANGED_CRITCHANCE_INCREASE_PERCENT = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(RANGED_DAMAGE_INCREASE_PERCENT, RANGED_CRITCHANCE_INCREASE_PERCENT);

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
            player.GetCritChance(DamageClass.Ranged) += RANGED_CRITCHANCE_INCREASE_PERCENT;
            player.aggro -= 400; // enemies are less likely to target you, same as Putrid Scent
        }

        public override void AddRecipes()
        {
            // crafted with 1 Putrid Scent and 1 Ranger Emblem at Tinkerer's Workshop
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PutridScent, 1);
            recipe.AddIngredient(ItemID.RangerEmblem, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
