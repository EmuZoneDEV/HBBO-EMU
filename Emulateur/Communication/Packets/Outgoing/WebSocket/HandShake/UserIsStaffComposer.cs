namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class UserIsStaffComposer : ServerPacket
    {
        public UserIsStaffComposer(bool IsStaff)
            : base(2)
        {
            base.WriteBoolean(IsStaff);
        }
    }
}
