using Butterfly.HabboHotel.Groups;
using System.Collections.Generic;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class GroupFurniConfigComposer : ServerPacket
    {
        public GroupFurniConfigComposer(ICollection<Group> groups)
            : base(ServerPacketHeader.GroupFurniConfigMessageComposer)
        {
            base.WriteInteger(groups.Count);
            foreach (Group group in groups)
            {
                base.WriteInteger(group.Id);
                base.WriteString(group.Name);
                base.WriteString(group.Badge);
                base.WriteString(ButterflyEnvironment.GetGame().GetGroupManager().GetColourCode(group.Colour1, true));
                base.WriteString(ButterflyEnvironment.GetGame().GetGroupManager().GetColourCode(group.Colour2, false));
                base.WriteBoolean(false);
                base.WriteInteger(group.CreatorId);
                base.WriteBoolean(group.ForumEnabled);
            }
        }
    }
}
