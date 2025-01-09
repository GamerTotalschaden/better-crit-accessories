using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class BeesStinger : ModItem
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
            player.GetArmorPenetration(DamageClass.Generic) += 5; // like Shark Tooth Necklace
            player.honeyCombItem = new Item(ItemID.HoneyComb); // Honey Comb effects (bees and honey when taking damage)
            player.panic = true; // Panic Necklace effect
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.StingerNecklace);
            recipe1.AddIngredient(ItemID.PanicNecklace);
            recipe1.AddTile(TileID.TinkerersWorkbench);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.SweetheartNecklace);
            recipe2.AddIngredient(ItemID.SharkToothNecklace);
            recipe2.AddTile(TileID.TinkerersWorkbench);
            recipe2.Register();
        }
    }
}
