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
        public static readonly Vector2 BEE_VELOCITY = new Vector2(0f, 0f); // initial velocity

        public bool Active = false;

        // the following variable will be set upon entering a world accordingly
        private int difficultyIndex = 0; // (0 = normal, 1 = expert, 2 = master)

        public override void ResetEffects()
        {
            Active = false;
        }

        public override void OnEnterWorld()
        {
            // update info according to difficulty (normal, expert, master)
            difficultyIndex = 0;
            if (Main.expertMode) difficultyIndex += 1; // also true for master mode
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
                // spawn giant bee projectile at the player's location
                // damage is doubled if Hive Pack is equipped
                bool hivePackEquipped = Player.strongBees;
                int damage = hivePackEquipped ? GetGiantBeeDamage() * 2 : GetGiantBeeDamage();

                Vector2 beePos = new Vector2(Player.position.X, Player.position.Y);
                SpawnGiantBeeProjectile(beePos, damage);
            }
        }

        private void SpawnGiantBeeProjectile(Vector2 position, int damage)
        {
            Projectile.NewProjectile(Main.LocalPlayer.GetSource_FromThis(), position,
                    BEE_VELOCITY, ProjectileID.GiantBee, damage, GIANT_BEE_KNOCKBACK, Main.myPlayer);
        }

        private int GetGiantBeeDamage()
        {
            return GIANT_BEE_DAMAGE[difficultyIndex];
        }

        private void SpawnBeeProjectile(Vector2 position, int damage)
        {
            Projectile.NewProjectile(Main.LocalPlayer.GetSource_FromThis(), position,
                    BEE_VELOCITY, ProjectileID.Bee, damage, BEE_KNOCKBACK, Main.myPlayer);
        }

        private int GetBeeDamage()
        {
            return BEE_DAMAGE[difficultyIndex];
        }
        
    }
}
