using BetterCritAccessories.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class RestoringNature : MutexModItem
    {
        public static readonly float CRIT_CHANCE_INCREASE_PERCENT = 5; // same as Diamond Jewel
        public static readonly float HEAL_PERCENTAGE_OF_DAMAGE = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CRIT_CHANCE_INCREASE_PERCENT, HEAL_PERCENTAGE_OF_DAMAGE);

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
            player.GetCritChance(DamageClass.Generic) += CRIT_CHANCE_INCREASE_PERCENT;
            player.GetModPlayer<HealOnCritPlayer>().AddCritHeal(DamageClass.Generic, HEAL_PERCENTAGE_OF_DAMAGE);
            player.GetModPlayer<NoLifeRegenPlayer>().NoLifeRegen = true;
        }

        public override void AddRecipes()
        {
            // crafted with 1 Diamond Jewel, 1 Adaptive Force, 5 Souls of Might & Fright & Sight at Orichalcum/Mythril Anvil
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient<DiamondJewel>();
            recipe.AddIngredient<AdaptiveForce>();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
