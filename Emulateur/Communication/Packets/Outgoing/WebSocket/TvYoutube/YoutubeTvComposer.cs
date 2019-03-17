namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class YoutubeTvComposer : ServerPacket
    {
        public YoutubeTvComposer(int ItemId, string VideoId)
            : base(3)
        {
            base.WriteInteger(ItemId);
            base.WriteString(VideoId);
        }
    }
}
