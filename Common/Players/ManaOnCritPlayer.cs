using BetterCritAccessories.Common.Util;
using Terraria;
using Terraria.ModLoader;

namespace BetterCritAccessories.Common.Players
{
    public class ManaOnCritPlayer : ModPlayer
    {
        public readonly DamageClass OnlyAffectedClass = DamageClass.Magic;

        public float ManaChancePercent = 0;
        public float ManaPercentageOfDamage = 0;

        public override void ResetEffects()
        {
            ManaChancePercent = 0;
            ManaPercentageOfDamage = 0;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!hit.Crit || ManaChancePercent <= 0 || ManaPercentageOfDamage <= 0)
            {
                return;
            }

            if (!OnlyAffectedClass.Equals(hit.DamageType))
            {
                return;
            }

            int manaAmount = DetermineManaAmount(damageDone);
            if (manaAmount > 0)
            {
                RestoreMana(manaAmount);
            }
        }

        private int DetermineManaAmount(int damageDone)
        {
            if (Player.statMana == Player.statManaMax2)
            {
                // already full mana
                return 0;
            }

            if (!Chance.HitPercent(ManaChancePercent)) {
                return 0;
            };

            return (int) (damageDone * ManaPercentageOfDamage / 100);
        }

        private void RestoreMana(int manaAmount)
        {
            // respect mana cap
            int currentMana = Player.statMana;
            if (currentMana + manaAmount > Player.statManaMax2)
            {
                manaAmount = Player.statManaMax2 - currentMana;
            }

            Player.statMana += manaAmount;
            Player.ManaEffect(manaAmount);
        }
    }
}
