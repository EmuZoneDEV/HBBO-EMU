namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UserNameChangeMessageComposer : ServerPacket
    {
        public UserNameChangeMessageComposer(string Name, int VirtualId)
            : base(ServerPacketHeader.UserNameChangeMessageComposer)
        {
            base.WriteInteger(0);
            base.WriteInteger(VirtualId);
            base.WriteString(Name);
        }
    }
}
