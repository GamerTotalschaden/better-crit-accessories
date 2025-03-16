using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace BetterCritAccessories.Content.Items.Accessories
{
    public abstract class MutexModItem : ModItem
    {
        public static readonly int[][] MutexGroups = [
                // Crit Heal and class-specific accessories
                [
                    /* Crit Heal */ ModContent.ItemType<AdaptiveForce>(), ModContent.ItemType<RestoringNature>(),
                    /* Melee */ ModContent.ItemType<PutridGlove>(), ModContent.ItemType<BruteForce>(),
                    /* Mage */ ModContent.ItemType<ArcaneRestoration>(),
                    /* Ranged */ ModContent.ItemType<SmellyEmblem>(), ModContent.ItemType<PreciseRestoration>(),
                    /* Summoner */ ModContent.ItemType<AllyEmblem>(), ModContent.ItemType<AlliedRestoration>()
                ],
                // Stinger tree
                [
                    ModContent.ItemType<BeesStinger>(), ModContent.ItemType<CriticalStinger>(), ModContent.ItemType<PenetratingCriticalStinger>()
                ]
                // important: when adding new mutex groups here, be sure to make the referenced item classes extend MutexModItem
            ];

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            int[][] itemMutexGroups = MutexGroups.Where(mutexGroup => mutexGroup.Contains(incomingItem.type)).ToArray();
            foreach (int[] mutexGroup in itemMutexGroups)
            {
                if (mutexGroup.Contains(equippedItem.type))
                {
                    return false;
                }
            }

            return true;
        }
    }
}