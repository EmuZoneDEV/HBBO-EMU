using Butterfly.HabboHotel.Groups;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ManageGroupComposer : ServerPacket
    {
        public ManageGroupComposer(Group Group, string[] BadgeParts)
            : base(ServerPacketHeader.ManageGroupMessageComposer)
        {
            base.WriteInteger(0);
            base.WriteBoolean(true);
            base.WriteInteger(Group.Id);
            base.WriteString(Group.Name);
            base.WriteString(Group.Description);
            base.WriteInteger(1);
            base.WriteInteger(Group.Colour1);
            base.WriteInteger(Group.Colour2);
            base.WriteInteger(Group.GroupType == GroupType.OPEN ? 0 : Group.GroupType == GroupType.LOCKED ? 1 : 2);
            base.WriteInteger(Group.AdminOnlyDeco);
            base.WriteBoolean(false);
            base.WriteString("");

            base.WriteInteger(5);

            for (int x = 0; x < BadgeParts.Length; x++)
            {
                string symbol = BadgeParts[x];
                int symbolInt = 0;

                this.WriteInteger((symbol.Length >= 6) ? (int.TryParse(symbol.Substring(0, 3), out symbolInt)) ? symbolInt : 0 : (int.TryParse(symbol.Substring(0, 2), out symbolInt)) ? symbolInt : 0);
                this.WriteInteger((symbol.Length >= 6) ? (int.TryParse(symbol.Substring(3, 2), out symbolInt)) ? symbolInt : 0 : (int.TryParse(symbol.Substring(2, 2), out symbolInt)) ? symbolInt : 0);
                this.WriteInteger(symbol.Length < 5 ? 0 : symbol.Length >= 6 ? (int.TryParse(symbol.Substring(5, 1), out symbolInt)) ? symbolInt : 0 : (int.TryParse(symbol.Substring(4, 1), out symbolInt)) ? symbolInt : 0);
            }

            int i = 0;
            while (i < (5 - BadgeParts.Length))
            {
                base.WriteInteger(0);
                base.WriteInteger(0);
                base.WriteInteger(0);
                i++;
            }

            base.WriteString(Group.Badge);
            base.WriteInteger(Group.MemberCount);
        }
    }
}
