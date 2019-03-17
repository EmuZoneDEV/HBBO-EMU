namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class BroadcastMessageAlertComposer : ServerPacket
    {
        public BroadcastMessageAlertComposer(string Message, string URL = "")
            : base(ServerPacketHeader.BroadcastMessageAlertMessageComposer)
        {
            base.WriteString(Message);
            base.WriteString(URL);
        }
    }
}
