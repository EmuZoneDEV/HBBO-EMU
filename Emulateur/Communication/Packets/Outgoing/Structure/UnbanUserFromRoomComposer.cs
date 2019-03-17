namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UnbanUserFromRoomComposer : ServerPacket
    {
        public UnbanUserFromRoomComposer(int RoomId, int UserId)
            : base(ServerPacketHeader.UnbanUserFromRoomMessageComposer)
        {
            base.WriteInteger(RoomId);
            base.WriteInteger(UserId);
        }
    }
}
