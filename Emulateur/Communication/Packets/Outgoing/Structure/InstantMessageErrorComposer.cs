namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class InstantMessageErrorComposer : ServerPacket
    {
        public InstantMessageErrorComposer(int Error, int Target)
            : base(ServerPacketHeader.InstantMessageErrorMessageComposer)
        {
            base.WriteInteger(Error);
            base.WriteInteger(Target);
            base.WriteString("");
        }
    }
}
