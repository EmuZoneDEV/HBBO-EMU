using Butterfly.HabboHotel.Achievements;
using Butterfly.HabboHotel.GameClients;
using System.Collections.Generic;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class AchievementsMessageComposer : ServerPacket
    {
        public AchievementsMessageComposer(GameClient Session, List<Achievement> Achievements)
            : base(ServerPacketHeader.AchievementsMessageComposer)
        {
            base.WriteInteger(Achievements.Count);
            foreach (Achievement achievement in Achievements)
            {
                UserAchievement achievementData = Session.GetHabbo().GetAchievementData(achievement.GroupName);
                int TargetLevel = achievementData != null ? achievementData.Level + 1 : 1;
                int count = achievement.Levels.Count;
                if (TargetLevel > count)
                    TargetLevel = count;
                AchievementLevel achievementLevel = achievement.Levels[TargetLevel];
                base.WriteInteger(achievement.Id);
                base.WriteInteger(TargetLevel);
                base.WriteString(achievement.GroupName + TargetLevel);
                base.WriteInteger(0);
                base.WriteInteger(achievementLevel.Requirement); //?
                base.WriteInteger(achievementLevel.RewardPixels);
                base.WriteInteger(0); //-1 = rien, 5 = PointWinwin?
                base.WriteInteger(achievementData != null ? achievementData.Progress : 0);
                base.WriteBoolean(achievementData != null && achievementData.Level >= count);
                base.WriteString(achievement.Category);
                base.WriteString(string.Empty);
                base.WriteInteger(count);
                base.WriteInteger(0);
            }
            base.WriteString(string.Empty);
        }
    }
}
