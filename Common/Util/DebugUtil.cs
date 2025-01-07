using Terraria.Chat;

namespace BetterCritAccessories.Common.Util
{
    internal class DebugUtil
    {
        internal static void ChatMessage(string msg, int r, int g, int b)
        {
            ChatHelper.BroadcastChatMessage(Terraria.Localization.NetworkText.FromLiteral(msg), new Microsoft.Xna.Framework.Color(r, g, b));
        }
        internal static void ChatMessage(string msg)
        {
            ChatMessage(msg, 255, 255, 255);
        }
    }
}
