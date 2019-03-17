using Butterfly.HabboHotel.GameClients;
using Butterfly.HabboHotel.Groups;
using Butterfly.HabboHotel.Users;
using System;
using System.Collections.Generic;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ProfileInformationComposer : ServerPacket
    {
        public ProfileInformationComposer(Habbo habbo, GameClient session, List<Group> groups, int friendCount)
            : base(ServerPacketHeader.ProfileInformationMessageComposer)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(habbo.AccountCreated);

            base.WriteInteger(habbo.Id);
            base.WriteString(habbo.Username);
            base.WriteString(habbo.Look);
            base.WriteString(habbo.Motto);
            base.WriteString(origin.ToString("dd/MM/yyyy"));
            base.WriteInteger(habbo.AchievementPoints);
            base.WriteInteger(friendCount); // Friend Count
            base.WriteBoolean(habbo.Id != session.GetHabbo().Id && session.GetHabbo().GetMessenger().FriendshipExists(habbo.Id)); //  Is friend
            base.WriteBoolean(habbo.Id != session.GetHabbo().Id && !session.GetHabbo().GetMessenger().FriendshipExists(habbo.Id) && session.GetHabbo().GetMessenger().RequestExists(habbo.Id)); // Sent friend request
            base.WriteBoolean((ButterflyEnvironment.GetGame().GetClientManager().GetClientByUserID(habbo.Id)) != null);

            base.WriteInteger(groups.Count);
            foreach (Group group in groups)
            {
                base.WriteInteger(group.Id);
                base.WriteString(group.Name);
                base.WriteString(group.Badge);
                base.WriteString(ButterflyEnvironment.GetGame().GetGroupManager().GetColourCode(group.Colour1, true));
                base.WriteString(ButterflyEnvironment.GetGame().GetGroupManager().GetColourCode(group.Colour2, false));
                base.WriteBoolean(habbo.FavouriteGroupId == group.Id); // todo favs
                base.WriteInteger(0);//what the fuck
                base.WriteBoolean(group != null ? group.ForumEnabled : true);//HabboTalk
            }

            base.WriteInteger(Convert.ToInt32(ButterflyEnvironment.GetUnixTimestamp() - habbo.LastOnline)); // Last online
            base.WriteBoolean(true); // Show the profile
        }
    }
}
