namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UpdateUsernameComposer : ServerPacket
    {
        public UpdateUsernameComposer(string User)
            : base(ServerPacketHeader.UpdateUsernameMessageComposer)
        {
            base.WriteInteger(0);
            base.WriteString(User);
            base.WriteInteger(0);
        }

        public UpdateUsernameComposer(string User, int VirtualId)
            : base(ServerPacketHeader.UpdateUsernameMessageComposer)
        {
            base.WriteInteger(VirtualId);
            base.WriteString(User);
            base.WriteInteger(1);
            base.WriteString(User);
        }
    }
}
