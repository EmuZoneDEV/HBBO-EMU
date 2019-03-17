namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ReceiveBadgeComposer : ServerPacket
    {
        public ReceiveBadgeComposer(string BadgeCode)
            : base(ServerPacketHeader.ReceiveBadgeMessageComposer)
        {
            base.WriteInteger(1);
            base.WriteString(BadgeCode);
        }
    }
}
