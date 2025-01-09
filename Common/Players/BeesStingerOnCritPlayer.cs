using BetterCritAccessories.Common.Util;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterCritAccessories.Common.Players
{
    public class BeesStingerOnCritPlayer : ModPlayer
    {
        public static readonly int PANIC_DURATION_SECONDS = 8; // like Panic Necklace
        public static readonly int HONEY_DURATION_SECONDS = 5; // like Honey Comb
        // like Bee Projectiles from Honey Comb:
        public static readonly int[] BEE_DAMAGE = { 13, 18, 26 };
        public static readonly float BEE_KNOCKBACK = 0f;
        public static readonly int[] GIANT_BEE_DAMAGE = { 18, 27, 36 };
        public static readonly float GIANT_BEE_KNOCKBACK = 0.5f;
        // this value is not from any wiki, but arbitrary from own testing
        public static readonly Vector2 BEE_VELOCITY = new Vector2(.5f, .5f);

        public bool Active = false;

        // the following variable will be set upon entering a world accordingly
        private int difficultyIndex = 0; // (0 = normal, 1 = expert, 2 = master)

        public override void ResetEffects()
        {
            Active = false;
        }

        public override void OnEnterWorld()
        {
            // update info if in expert mode
            difficultyIndex = 0;
            if (Main.expertMode) difficultyIndex += 1;
            if (Main.masterMode) difficultyIndex += 1;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!Active || !hit.Crit)
            {
                return;
            }

            Player.AddBuff(BuffID.Panic, PANIC_DURATION_SECONDS * 60);
            Player.AddBuff(BuffID.Honey, HONEY_DURATION_SECONDS * 60);

            if (Main.myPlayer == Player.whoAmI)
            {
                SpawnBeeProjectiles();
            }
        }

        private void SpawnBeeProjectiles()
        {
            /*
             * TODO clarify:
             * 
             * 1. should multiple bees be spawned? If so, investigate how this can be done,
             *    because it does not seem to work with a for loop.
             *    Alternatively spawn only one bee (as multiple might be OP, since they can the projectiles can crit itself again),
             *    or spawn only one giant bee?
             * 
             * 2. consider hive pack effects (like honey comb)?
             *    50% chance for giant bees, and chance for an additional bee to spawn
             *    
             */

            int maxBeeCount = 3;
            if (difficultyIndex > 0) maxBeeCount += 1; // chance for 1 additional bee in expert mode

            for (int i = 0; i < maxBeeCount; i++)
            {
                Vector2 beePos = new Vector2(Player.position.X, Player.position.Y);
                if (i == 0) // always spawn 1 bee
                {
                    SpawnBeeProjectile(beePos);
                    continue;
                }
                // spawn remaining bees with a 33% chance each (like Honey Comb)
                if (Chance.HitPercent(33))
                {
                    SpawnBeeProjectile(beePos);
                }
            }
        }

        private void SpawnBeeProjectile(Vector2 position)
        {
            Projectile.NewProjectile(Main.LocalPlayer.GetSource_FromThis(), position,
                    BEE_VELOCITY, ProjectileID.Bee, GetBeeDamage(), BEE_KNOCKBACK, Main.myPlayer);
        }

        private void SpawnGiantBeeProjectile(Vector2 position)
        {
            Projectile.NewProjectile(Main.LocalPlayer.GetSource_FromThis(), position,
                    BEE_VELOCITY, ProjectileID.GiantBee, GetGiantBeeDamage(), GIANT_BEE_KNOCKBACK, Main.myPlayer);
        }

        private int GetBeeDamage()
        {
            return BEE_DAMAGE[difficultyIndex];
        }

        private int GetGiantBeeDamage()
        {
            return GIANT_BEE_DAMAGE[difficultyIndex];
        }
    }
}
