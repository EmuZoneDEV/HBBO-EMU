namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UserRemoveComposer : ServerPacket
    {
        public UserRemoveComposer(int Id)
            : base(ServerPacketHeader.UserRemoveMessageComposer)
        {
            base.WriteString(Id.ToString());
        }
    }
}
