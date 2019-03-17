namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class PublicCategories : ServerPacket
    {
        public PublicCategories()
            : base(ServerPacketHeader.PublicCategories)
        {
			
        }
    }
}
