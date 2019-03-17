namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class CarryObjectComposer : ServerPacket
    {
        public CarryObjectComposer(int virtualID, int itemID)
            : base(ServerPacketHeader.CarryObjectMessageComposer)
        {
            base.WriteInteger(virtualID);
            base.WriteInteger(itemID);
        }
    }
}
