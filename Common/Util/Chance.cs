using System;
using Terraria;

namespace BetterCritAccessories.Common.Util
{
    internal class Chance
    {
        internal static bool Hit(double odds, Random random)
        {
            return random.NextDouble() < odds;
        }

        internal static bool Hit(double odds, Terraria.Utilities.UnifiedRandom random)
        {
            return random.NextDouble() < odds;
        }

        internal static bool Hit(double odds)
        {
            return Chance.Hit(odds, Main.rand);
        }

        internal static bool HitPercent(double oddsPercent, Random random)
        {
            return Chance.Hit(oddsPercent / 100, random);
        }

        internal static bool HitPercent(double oddsPercent, Terraria.Utilities.UnifiedRandom random)
        {
            return Chance.Hit(oddsPercent / 100, random);
        }

        internal static bool HitPercent(double oddsPercent)
        {
            return Chance.Hit(oddsPercent / 100, Main.rand);
        }
    }
}
