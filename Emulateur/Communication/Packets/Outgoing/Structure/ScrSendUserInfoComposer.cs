namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ScrSendUserInfoComposer : ServerPacket
    {
        public ScrSendUserInfoComposer()
            : base(ServerPacketHeader.ScrSendUserInfoMessageComposer)
        {
            int DisplayMonths = 0;
            int DisplayDays = 0;

            base.WriteString("habbo_club");
            base.WriteInteger(DisplayDays);
            base.WriteInteger(2);
            base.WriteInteger(DisplayMonths);
            base.WriteInteger(1);
            base.WriteBoolean(true); // hc
            base.WriteBoolean(true); // vip
            base.WriteInteger(0);
            base.WriteInteger(0);
            base.WriteInteger(495);
        }
    }
}
