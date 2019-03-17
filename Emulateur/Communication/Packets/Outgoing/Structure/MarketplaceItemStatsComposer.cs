namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class MarketplaceItemStatsComposer : ServerPacket
    {
        public MarketplaceItemStatsComposer(int ItemId, int SpriteId, int AveragePrice)
            : base(ServerPacketHeader.MarketplaceItemStatsMessageComposer)
        {
            base.WriteInteger(AveragePrice);//Avg price in last 7 days.
            base.WriteInteger(ButterflyEnvironment.GetGame().GetCatalog().GetMarketplace().OfferCountForSprite(SpriteId));
            base.WriteInteger(7);//Day

            base.WriteInteger(4);//Count
            {
                base.WriteInteger(1); // Jour ?
                base.WriteInteger(2); // Prix moyen
                base.WriteInteger(1); // Volume échange

                base.WriteInteger(1); //x
                base.WriteInteger(2); //?
                base.WriteInteger(2); //y

                base.WriteInteger(3); //x
                base.WriteInteger(5);
                base.WriteInteger(3); //y

                base.WriteInteger(1); //x
                base.WriteInteger(7); //?
                base.WriteInteger(4); //y
            }

            base.WriteInteger(ItemId);
            base.WriteInteger(SpriteId);
        }
    }
}
