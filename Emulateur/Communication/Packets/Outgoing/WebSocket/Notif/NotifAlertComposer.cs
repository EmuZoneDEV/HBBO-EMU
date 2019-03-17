namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class NotifAlertComposer : ServerPacket
    {
        public NotifAlertComposer(string Image, string Title, string Message, string TextButton, int RoomId, string Url)
         : base(12)
        {
            base.WriteString(Image);
            base.WriteString(Title);
            base.WriteString(Message);
            base.WriteString(TextButton);
            base.WriteInteger(RoomId);
            base.WriteString(Url);
        }
    }
}
