using BetterCritAccessories.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class CriticalStinger : MutexModItem
    {
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
            player.GetArmorPenetration(DamageClass.Generic) += 5; // like Shark Tooth Necklace and Bee's Stinger
            player.GetModPlayer<BeesStingerOnCritPlayer>().Active = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<BeesStinger>();
            recipe.AddIngredient<DiamondJewel>();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
