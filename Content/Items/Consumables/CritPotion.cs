using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Consumables
{
    public class CritPotion : ModItem
    {
        public static readonly float CRIT_CHANCE_INCREASE_PERCENT = 10;
        public static readonly float CRIT_DAMAGE_INCREASE_PERCENT = 5;
        public static readonly int BUFF_DURATION_MINUTES = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(
            CRIT_CHANCE_INCREASE_PERCENT, CRIT_DAMAGE_INCREASE_PERCENT);

        public override void SetDefaults()
        {
            // stats here mostly copied from ExampleBuffPotion from example mod
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(silver: 40);
            Item.buffType = ModContent.BuffType<Buffs.CritPotionBuff>();
            Item.buffTime = BUFF_DURATION_MINUTES * 60 * 60; // x minutes (x * 60 seconds * 60 ticks/second)
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}
