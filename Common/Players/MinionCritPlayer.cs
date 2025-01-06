using BetterCritAccessories.Common.Util;
using Terraria;
using Terraria.Chat;
using Terraria.ModLoader;

namespace BetterCritAccessories.Common.Players
{
    public class MinionCritPlayer : ModPlayer
    {
        public float CRIT_CHANCE_PERCENT = 0;

        public override void ResetEffects()
        {
            CRIT_CHANCE_PERCENT = 0;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            bool isMinionHit = modifiers.ToHitInfo(0, false, 0).DamageType == DamageClass.Summon;
            if (isMinionHit && Chance.HitPercent(CRIT_CHANCE_PERCENT))
            {
                modifiers.SetCrit();
            }
        }
    }
}
