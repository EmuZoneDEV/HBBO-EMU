namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class FigureSetIdsComposer : ServerPacket
    {
        public FigureSetIdsComposer()
            : base(ServerPacketHeader.FigureSetIdsMessageComposer)
        {
            base.WriteInteger(0);

            base.WriteInteger(0);
        }
    }
}
