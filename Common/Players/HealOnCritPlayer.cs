using BetterCritAccessories.Common.Util;
using Terraria;
using Terraria.ModLoader;

namespace BetterCritAccessories.Common.Players
{
    public class HealOnCritPlayer : ModPlayer
    {
        public float HealChancePercent = 0;
        public float HealPercentageOfDamage = 0;
        public DamageClass OnlyAffectedClass = null; // if null: no additional check for damage class

        public override void ResetEffects()
        {
            HealChancePercent = 0;
            HealPercentageOfDamage = 0;
            OnlyAffectedClass = null;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!hit.Crit || HealChancePercent <= 0 || HealPercentageOfDamage <= 0)
            {
                return;
            }

            if (OnlyAffectedClass != null && !OnlyAffectedClass.Equals(hit.DamageType))
            {
                return;
            }

            int healAmount = DetermineHealAmount(damageDone);
            if (healAmount > 0)
            {
                Player.Heal(healAmount);
            }
        }

        private int DetermineHealAmount(int damageDone)
        {
            if (!Chance.HitPercent(HealChancePercent)) return 0;

            return (int) (damageDone * HealPercentageOfDamage / 100);
        }
    }
}
