using BetterCritAccessories.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class AdaptiveForce : ModItem
    {
        public static readonly float HEAL_CHANCE_PERCENT = 20;
        public static readonly float HEAL_PERCENTAGE_OF_DAMAGE = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(HEAL_CHANCE_PERCENT, HEAL_PERCENTAGE_OF_DAMAGE);

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
            player.GetModPlayer<HealOnCritPlayer>().AddCritHeal(DamageClass.Generic, HEAL_CHANCE_PERCENT, HEAL_PERCENTAGE_OF_DAMAGE);
        }

        public override void AddRecipes()
        {
            // crafted with 7 Hallowed Bars, 3 Jungle Spores, 1 Life Crystal at Mythril/Orichalcum Anvil
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 7);
            recipe.AddIngredient(ItemID.JungleSpores, 3);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.Register();
        }
    }
}
