namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UnknownGroupComposer : ServerPacket
    {
        public UnknownGroupComposer(int GroupId, int HabboId)
            : base(ServerPacketHeader.UnknownGroupMessageComposer)
        {
            base.WriteInteger(GroupId);
            base.WriteInteger(HabboId);
        }
    }
}
