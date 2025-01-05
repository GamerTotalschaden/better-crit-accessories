using Terraria.ID;
using Terraria.ModLoader;

namespace BetterCritAccessories.Common.Systems
{
    public class CustomRecipes : ModSystem
    {
        public override void SetStaticDefaults()
        {
            // add shimmer recipies

            // Flesh Knuckles into Putrid Scent (and vice versa)
            ItemID.Sets.ShimmerTransformToItem[ItemID.FleshKnuckles] = ItemID.PutridScent;
            ItemID.Sets.ShimmerTransformToItem[ItemID.PutridScent] = ItemID.FleshKnuckles;

            // Panic Necklace into Band Of Starpower (and vice versa)
            ItemID.Sets.ShimmerTransformToItem[ItemID.PanicNecklace] = ItemID.BandofStarpower;
            ItemID.Sets.ShimmerTransformToItem[ItemID.BandofStarpower] = ItemID.PanicNecklace;
        }

        // other recipies can be added here by overriding AddRecipes()
    }
}
