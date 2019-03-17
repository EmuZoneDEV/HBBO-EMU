using Butterfly.HabboHotel.GameClients;
using Butterfly.HabboHotel.Rooms;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UserChangeComposer : ServerPacket
    {
        public UserChangeComposer(RoomUser User, bool Self)
            : base(ServerPacketHeader.UserChangeMessageComposer)
        {
            base.WriteInteger((Self) ? -1 : User.VirtualId);
            base.WriteString(User.GetClient().GetHabbo().Look);
            base.WriteString(User.GetClient().GetHabbo().Gender);
            base.WriteString(User.GetClient().GetHabbo().Motto);
            base.WriteInteger(User.GetClient().GetHabbo().AchievementPoints);
        }

        public UserChangeComposer(RoomUser User) //Bot
            : base(ServerPacketHeader.UserChangeMessageComposer)
        {
            base.WriteInteger(User.VirtualId);
            base.WriteString(User.BotData.Look);
            base.WriteString(User.BotData.Gender);
            base.WriteString(User.BotData.Motto);
            base.WriteInteger(0);
        }

        public UserChangeComposer(GameClient Client)
            : base(ServerPacketHeader.UserChangeMessageComposer)
        {
            base.WriteInteger(-1);
            base.WriteString(Client.GetHabbo().Look);
            base.WriteString(Client.GetHabbo().Gender);
            base.WriteString(Client.GetHabbo().Motto);
            base.WriteInteger(Client.GetHabbo().AchievementPoints);
        }
    }
}
