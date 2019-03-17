namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class RemoveItemInventoryRpComposer : ServerPacket
    {
        public RemoveItemInventoryRpComposer(int ItemId, int Count)
          : base(11)
        {
            base.WriteInteger(ItemId);
            base.WriteInteger(Count);
        }
    }
}
