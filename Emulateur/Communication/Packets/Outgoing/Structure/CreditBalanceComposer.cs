namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class CreditBalanceComposer : ServerPacket
    {
        public CreditBalanceComposer(int creditsBalance)
            : base(ServerPacketHeader.CreditBalanceMessageComposer)
        {
            base.WriteString(creditsBalance + ".0");
        }
    }
}
