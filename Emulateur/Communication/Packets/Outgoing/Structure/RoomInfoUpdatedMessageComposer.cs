namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class RoomInfoUpdatedMessageComposer : ServerPacket
    {
        public RoomInfoUpdatedMessageComposer(int RoomId)
            : base(ServerPacketHeader.RoomInfoUpdatedMessageComposer)
        {
            base.WriteInteger(RoomId);
        }
    }
}