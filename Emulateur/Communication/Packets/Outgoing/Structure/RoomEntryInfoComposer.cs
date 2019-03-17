namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class RoomEntryInfoComposer : ServerPacket
    {
        public RoomEntryInfoComposer(int roomID, bool isOwner)
            : base(ServerPacketHeader.RoomEntryInfoMessageComposer)
        {
            base.WriteInteger(roomID);
            base.WriteBoolean(isOwner);
        }
    }
}
