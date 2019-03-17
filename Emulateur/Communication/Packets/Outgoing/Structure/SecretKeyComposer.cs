namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    public class SecretKeyComposer : ServerPacket
    {
        public SecretKeyComposer(string PublicKey)
            : base(ServerPacketHeader.SecretKeyMessageComposer)
        {
            base.WriteString(PublicKey);
            base.WriteBoolean(false);
        }
    }
}