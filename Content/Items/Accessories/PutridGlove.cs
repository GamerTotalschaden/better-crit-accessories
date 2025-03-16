using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public class PutridGlove : MutexModItem
    {
        public static readonly float MELEE_DAMAGE_AND_SPEED_INCREASE_PERCENT = 12;
        public static readonly float MELEE_CRIT_CHANCE_INCREASE_PERCENT = 7;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(
            MELEE_CRIT_CHANCE_INCREASE_PERCENT, MELEE_DAMAGE_AND_SPEED_INCREASE_PERCENT);

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
            // Effects on top of Mechanical Glove
            player.GetCritChance(DamageClass.Melee) += MELEE_CRIT_CHANCE_INCREASE_PERCENT;
            // Mechanical Glove
            player.GetKnockback(DamageClass.Melee) += 1f;
            player.GetDamage(DamageClass.Melee) += MELEE_DAMAGE_AND_SPEED_INCREASE_PERCENT / 100;
            player.GetAttackSpeed(DamageClass.Melee) += MELEE_DAMAGE_AND_SPEED_INCREASE_PERCENT / 100;
            player.autoReuseGlove = true; // enables autoswing
            player.meleeScaleGlove = true; // increases weapon size by 10%
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (!base.CanAccessoryBeEquippedWith(equippedItem, incomingItem, player))
            {
                return false;
            }

            // cannot be used with Fire Gauntlet
            if (incomingItem.type == ItemID.FireGauntlet)
            {
                return false;
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MechanicalGlove);
            recipe.AddIngredient(ItemID.PutridScent);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
