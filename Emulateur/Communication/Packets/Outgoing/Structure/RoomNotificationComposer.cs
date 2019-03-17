namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class RoomNotificationComposer : ServerPacket
    {
        public RoomNotificationComposer(string Type, string Key, string Value)
           : base(ServerPacketHeader.RoomNotificationMessageComposer)
        {
            base.WriteString(Type);
            base.WriteInteger((Type == "furni_placement_error") ? 2 : 1);//Count
            {
                if(Type == "furni_placement_error")
                {
                    base.WriteString("display");
                    base.WriteString("BUBBLE");
                }
                base.WriteString(Key);//Type of message
                base.WriteString(Value);
            }
        }

        public RoomNotificationComposer(string Type)
            : base(ServerPacketHeader.RoomNotificationMessageComposer)
        {
            base.WriteString(Type);
            base.WriteInteger(0);//Count
        }

        public RoomNotificationComposer(string Title, string Message, string Image, string HotelName, string HotelURL)
            : base(ServerPacketHeader.RoomNotificationMessageComposer)
        {
            int CountMessage = 2;
            if (!string.IsNullOrEmpty(HotelName))
                CountMessage = CountMessage + 2;

            base.WriteString(Image);
            base.WriteInteger(CountMessage);
            base.WriteString("title");
            base.WriteString(Title);
            base.WriteString("message");
            base.WriteString(Message);

            if (!string.IsNullOrEmpty(HotelName))
            {
                base.WriteString("linkUrl");
                base.WriteString(HotelURL);
                base.WriteString("linkTitle");
                base.WriteString(HotelName);
            }
        }
    }
}
