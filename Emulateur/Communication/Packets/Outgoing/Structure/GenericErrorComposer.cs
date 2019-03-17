namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class GenericErrorComposer : ServerPacket
    {
        public GenericErrorComposer(int errorId)
            : base(ServerPacketHeader.GenericErrorMessageComposer)
        {
            base.WriteInteger(errorId);
        }
    }
}
