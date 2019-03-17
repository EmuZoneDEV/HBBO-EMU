namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class MarketplaceConfigurationComposer : ServerPacket
    {
        public MarketplaceConfigurationComposer()
            : base(ServerPacketHeader.MarketplaceConfigurationMessageComposer)
        {
            base.WriteBoolean(true);
            base.WriteInteger(0);//Min price.
            base.WriteInteger(0);//1?
            base.WriteInteger(0);//5?
            base.WriteInteger(1);// Prix Minimum
            base.WriteInteger(9999);//Max price.
            base.WriteInteger(48);
            base.WriteInteger(7);//Days.
        }
    }
}
