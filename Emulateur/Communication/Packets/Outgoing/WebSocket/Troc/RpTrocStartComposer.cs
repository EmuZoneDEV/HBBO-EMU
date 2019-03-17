namespace Butterfly.Communication.Packets.Outgoing.WebSocket.Troc
{
    class RpTrocStartComposer : ServerPacket
    {
        public RpTrocStartComposer(int UserId, string Username)
          : base(13)
        {
            base.WriteInteger(UserId);
            base.WriteString(Username);
        }
    }
}
