using Terraria;
using Terraria.ModLoader;

namespace BetterCritAccessories.Common.Players
{
    public class NoLifeRegenPlayer : ModPlayer
    {

        public bool NoLifeRegen = false;

        public override void ResetEffects()
        {
            NoLifeRegen = false;
        }

        public override void NaturalLifeRegen(ref float regen)
        {
            if (NoLifeRegen)
            {
                regen = 0;
            }
        }

        public override void UpdateLifeRegen()
        {
            if (NoLifeRegen && Player.lifeRegen > 0)
            {
                Player.lifeRegen = 0;
            }
        }
    }
}
