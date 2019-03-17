namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class GroupAreYouSureMessageComposer : ServerPacket
    {
        public GroupAreYouSureMessageComposer()
            : base(ServerPacketHeader.GroupAreYouSureMessageComposer)
        {
			
        }
    }
}
