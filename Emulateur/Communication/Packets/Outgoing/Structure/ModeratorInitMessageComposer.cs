namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ModeratorInitMessageComposer : ServerPacket
    {
        public ModeratorInitMessageComposer()
            : base(ServerPacketHeader.ModeratorInitMessageComposer)
        {
			
        }
    }
}
