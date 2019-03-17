namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class HabboActivityPointNotificationComposer : ServerPacket
    {
        public HabboActivityPointNotificationComposer(int Balance, int Notif, int currencyType = 0)
            : base(ServerPacketHeader.HabboActivityPointNotificationMessageComposer)
        {
            base.WriteInteger(Balance);
            base.WriteInteger(Notif);
            base.WriteInteger(currencyType);//Type
        }
    }
}
