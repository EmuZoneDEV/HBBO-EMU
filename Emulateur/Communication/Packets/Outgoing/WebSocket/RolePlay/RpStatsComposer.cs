namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class RpStatsComposer : ServerPacket
    {
        public RpStatsComposer(int pRpId, int pHealth, int pHealMax, int pEnergy, int pMoney, int pMunition, int pLevel)
            : base(6)
        {
            base.WriteInteger(pRpId);
            base.WriteInteger(pHealth);
            base.WriteInteger(pHealMax);
            base.WriteInteger(pEnergy);
            base.WriteInteger(pMoney);
            base.WriteInteger(pMunition);
            base.WriteInteger(pLevel);
        }
    }
}
