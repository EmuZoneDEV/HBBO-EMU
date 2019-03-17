using Butterfly.HabboHotel.Users;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UserObjectComposer : ServerPacket
    {
        public UserObjectComposer(Habbo Habbo)
            : base(ServerPacketHeader.UserObjectMessageComposer)
        {
            base.WriteInteger(Habbo.Id);
            base.WriteString(Habbo.Username);
            base.WriteString(Habbo.Look);
            base.WriteString(Habbo.Gender.ToUpper());
            base.WriteString(Habbo.Motto);
            base.WriteString("");
            base.WriteBoolean(false);
            base.WriteInteger(Habbo.Respect);
            base.WriteInteger(Habbo.DailyRespectPoints);
            base.WriteInteger(Habbo.DailyPetRespectPoints);
            base.WriteBoolean(false); // Friends stream active
            base.WriteString(Habbo.LastOnline.ToString()); // last online?
            base.WriteBoolean(Habbo.Rank > 1 || Habbo.CanChangeName); // Can change name
            base.WriteBoolean(false);
        }
    }
}
