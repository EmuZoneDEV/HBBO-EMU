namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class InitCryptoComposer : ServerPacket
    {
        public InitCryptoComposer(string Prime, string Generator)
            : base(ServerPacketHeader.InitCryptoMessageComposer)
        {
            base.WriteString(Prime);
            base.WriteString(Generator);
        }
    }
}
