namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class YouAreControllerComposer : ServerPacket
    {
        public YouAreControllerComposer(int Setting)
            : base(ServerPacketHeader.YouAreControllerMessageComposer)
        {
            base.WriteInteger(Setting);
        }
    }
}
