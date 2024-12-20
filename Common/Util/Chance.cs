using System;

namespace BetterCritAccessories.Common.Util
{
    internal class Chance
    {
        private static readonly Random LOCAL_RANDOM = new Random();

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
            return Chance.Hit(odds, LOCAL_RANDOM);
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
            return Chance.Hit(oddsPercent / 100, LOCAL_RANDOM);
        }
    }
}
