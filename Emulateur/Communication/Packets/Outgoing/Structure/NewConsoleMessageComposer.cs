namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class NewConsoleMessageComposer : ServerPacket
    {
        public NewConsoleMessageComposer(int Sender, string Message, int Time = 0)
            : base(ServerPacketHeader.NewConsoleMessageMessageComposer)
        {
            base.WriteInteger(Sender);
            base.WriteString(Message);
            base.WriteInteger(Time);
        }
    }
}
