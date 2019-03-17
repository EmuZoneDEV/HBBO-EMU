using Butterfly.HabboHotel.Achievements;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class AchievementUnlockedMessageComposer : ServerPacket
    {
        public AchievementUnlockedMessageComposer(Achievement Achievement, int Level, int PointReward, int PixelReward)
            : base(ServerPacketHeader.AchievementUnlockedMessageComposer)
        {
            base.WriteInteger(Achievement.Id);
            base.WriteInteger(Level);
            base.WriteInteger(144);
            base.WriteString(Achievement.GroupName + Level);
            base.WriteInteger(PointReward);
            base.WriteInteger(PixelReward);
            base.WriteInteger(0);
            base.WriteInteger(10);
            base.WriteInteger(21);
            base.WriteString(Level > 1 ? Achievement.GroupName + (Level - 1) : string.Empty);
            base.WriteString(Achievement.Category);
            base.WriteString(string.Empty);
        }
    }
}
