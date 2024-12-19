using Terraria;
using Terraria.ModLoader;

namespace BetterCritAccessories.Common.Players
{
    public class ModifiedCritDamagePlayer : ModPlayer
    {
        public float ModifiedCritDamagePercent = 0;

        public override void ResetEffects()
        {
            ModifiedCritDamagePercent = 0;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.CritDamage += ModifiedCritDamagePercent / 100;
        }
    }
}
