namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ObjectRemoveMessageComposer : ServerPacket
    {
        public ObjectRemoveMessageComposer(int ItemId, int OwnerId)
            : base(ServerPacketHeader.ObjectRemoveMessageComposer)
        {
            base.WriteString(ItemId.ToString());
            base.WriteBoolean(false); //isExpired
            base.WriteInteger(OwnerId);
            base.WriteInteger(0);
        }
    }
}
