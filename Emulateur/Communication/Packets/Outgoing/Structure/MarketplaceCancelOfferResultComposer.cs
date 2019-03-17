namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class MarketplaceCancelOfferResultComposer : ServerPacket
    {
        public MarketplaceCancelOfferResultComposer(int OfferId, bool Success)
            : base(ServerPacketHeader.MarketplaceCancelOfferResultMessageComposer)
        {
            base.WriteInteger(OfferId);
            base.WriteBoolean(Success);
        }
    }
}
