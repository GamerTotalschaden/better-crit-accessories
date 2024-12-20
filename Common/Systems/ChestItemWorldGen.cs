using BetterCritAccessories.Common.Util;
using BetterCritAccessories.Content.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterCritAccessories.Common.Systems
{
    public class ChestItemWorldGen : ModSystem
    {
        public readonly float CRITICAL_MASTERY_CHANCE_PERCENT = 20;

        public override void PostWorldGen()
        {
            // loop over all generated chests in the freshly generated world
            for (int chestIndex = 0; chestIndex < Main.maxChests; ++chestIndex)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest == null)
                {
                    continue;
                }
                Tile chestTile = Main.tile[chest.x, chest.y];

                int lockedGoldenChestTileIndex = 2; // column index in Tiles_21.png (chest sprite sheet) to check/filter chest type
                // (see: https://github.com/RiptideStudio/RiptideMod/blob/main/Tiles_21.png)

                if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == lockedGoldenChestTileIndex * 36)
                {
                    // Locked Golden Chests (in dungeon)

                    // Critical Mastery generation
                    if (!Chance.HitPercent(CRITICAL_MASTERY_CHANCE_PERCENT, WorldGen.genRand))
                    {
                        continue;
                    }
                    chest.item[0].SetDefaults(ModContent.ItemType<CriticalMastery>());
                    chest.item[0].stack = 1;
                }
            }
        }
    }
}
