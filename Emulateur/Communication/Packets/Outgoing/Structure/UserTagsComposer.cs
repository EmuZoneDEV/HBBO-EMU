namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UserTagsComposer : ServerPacket
    {
        public UserTagsComposer(int UserId)
            : base(ServerPacketHeader.UserTagsMessageComposer)
        {
            base.WriteInteger(UserId);
            base.WriteInteger(2);//Count of the tags.
            {
                base.WriteString("Wibbo.me");
                base.WriteString("test");
                //Append a string.
            }
        }
    }
}
