using System.Collections.Generic;
using BetterCritAccessories.Common.Util;
using Terraria;
using Terraria.ModLoader;

namespace BetterCritAccessories.Common.Players
{
    public class HealOnCritPlayer : ModPlayer
    {
        private class ItemParams
        {
            internal DamageClass damageClass;
            internal float HealChancePercent;
            internal float HealPercentageOfDamage;

            internal ItemParams(DamageClass damageClass, float healChancePercent, float healPercentageOfDamage)
            {
                this.damageClass = damageClass;
                this.HealChancePercent = healChancePercent;
                this.HealPercentageOfDamage = healPercentageOfDamage;
            }
        }
        private readonly List<ItemParams> ActiveItems = new List<ItemParams>();

        public void AddCritHeal(DamageClass damageClass, float healPercentageOfDamage)
        {
            AddCritHeal(damageClass, 100, healPercentageOfDamage);
        }

        public void AddCritHeal(DamageClass damageClass, float healChancePercent, float healPercentageOfDamage)
        {
            ItemParams affectedClassParams = new ItemParams(damageClass, healChancePercent, healPercentageOfDamage);
            ActiveItems.Add(affectedClassParams);
        }

        public override void ResetEffects()
        {
            ActiveItems.Clear();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!hit.Crit)
            {
                return;
            }

            int healAmount = 0;
            foreach (ItemParams itemParams in ActiveItems)
            {
                if (itemParams.damageClass == DamageClass.Generic || itemParams.damageClass == hit.DamageType)
                {
                    healAmount += DetermineHealAmount(itemParams, damageDone);
                }
            }

            if (healAmount > 0)
            {
                Player.Heal(healAmount);
            }
        }
        private int DetermineHealAmount(ItemParams affectedClassParams, int damageDone)
        {
            if (!Chance.HitPercent(affectedClassParams.HealChancePercent)) return 0;

            return (int) (damageDone * affectedClassParams.HealPercentageOfDamage / 100);
        }
    }
}
