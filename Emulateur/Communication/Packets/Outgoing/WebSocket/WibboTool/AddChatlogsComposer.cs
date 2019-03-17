namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class AddChatlogsComposer : ServerPacket
    {
        public AddChatlogsComposer(int UserId, string Pseudo, string Message)
          : base(7)
        {
            base.WriteInteger(UserId);
            base.WriteString(Pseudo);
            base.WriteString(Message);
        }
    }
}