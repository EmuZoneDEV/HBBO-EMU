namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class PlaySoundComposer : ServerPacket
    {
        public PlaySoundComposer(string Name, int Type)
            : base(21)
        {
            WriteString(Name);
            WriteInteger(Type);
        }
    }
}
