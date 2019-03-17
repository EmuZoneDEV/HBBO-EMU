namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class CatalogUpdatedComposer : ServerPacket
    {
        public CatalogUpdatedComposer()
            : base(ServerPacketHeader.CatalogUpdatedMessageComposer)
        {
            base.WriteBoolean(false);
        }
    }
}
