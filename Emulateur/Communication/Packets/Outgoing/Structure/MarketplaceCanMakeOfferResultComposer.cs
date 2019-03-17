namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class MarketplaceCanMakeOfferResultComposer : ServerPacket
    {
        public MarketplaceCanMakeOfferResultComposer(int Result)
            : base(ServerPacketHeader.MarketplaceCanMakeOfferResultMessageComposer)
        {
            base.WriteInteger(Result);
            base.WriteInteger(0);
        }
    }
}
