namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class MessengerInitComposer : ServerPacket
    {
        public MessengerInitComposer()
            : base(ServerPacketHeader.MessengerInitMessageComposer)
        {
            base.WriteInteger(2000);
            base.WriteInteger(300);
            base.WriteInteger(800);
            base.WriteInteger(0);
        }
    }
}
