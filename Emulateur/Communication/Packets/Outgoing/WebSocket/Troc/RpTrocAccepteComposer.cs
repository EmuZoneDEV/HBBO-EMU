namespace Butterfly.Communication.Packets.Outgoing.WebSocket.Troc
{
    class RpTrocAccepteComposer : ServerPacket
    {
        public RpTrocAccepteComposer(int UserId, bool Etat)
          : base(15)
        {
            base.WriteInteger(UserId);
            base.WriteBoolean(Etat);
        }
    }
}
