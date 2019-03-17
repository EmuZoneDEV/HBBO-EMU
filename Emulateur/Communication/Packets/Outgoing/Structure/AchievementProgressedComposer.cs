using Butterfly.HabboHotel.Achievements;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class AchievementProgressedComposer : ServerPacket
    {
        public AchievementProgressedComposer(Achievement Achievement, int TargetLevel, AchievementLevel TargetLevelData, int TotalLevels, UserAchievement UserData)
            : base(ServerPacketHeader.AchievementProgressedMessageComposer)
        {
            base.WriteInteger(Achievement.Id);
            base.WriteInteger(TargetLevel);
            base.WriteString(Achievement.GroupName + TargetLevel);
            base.WriteInteger(0);
            base.WriteInteger(TargetLevelData.Requirement);
            base.WriteInteger(TargetLevelData.RewardPixels);
            base.WriteInteger(0);
            base.WriteInteger(UserData != null ? UserData.Progress : 0);
            base.WriteBoolean(UserData != null && UserData.Level >= TotalLevels);
            base.WriteString(Achievement.Category);
            base.WriteString(string.Empty);
            base.WriteInteger(TotalLevels);
            base.WriteInteger(0);
        }
    }
}
