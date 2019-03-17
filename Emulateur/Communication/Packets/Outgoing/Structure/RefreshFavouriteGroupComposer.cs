namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class RefreshFavouriteGroupComposer : ServerPacket
    {
        public RefreshFavouriteGroupComposer(int Id)
            : base(ServerPacketHeader.RefreshFavouriteGroupMessageComposer)
        {
            base.WriteInteger(Id);
        }
    }
}
