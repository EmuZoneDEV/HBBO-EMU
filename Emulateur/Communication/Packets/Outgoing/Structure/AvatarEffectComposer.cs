namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class AvatarEffectComposer : ServerPacket
    {
        public AvatarEffectComposer(int playerID, int effectID)
            : base(ServerPacketHeader.AvatarEffectMessageComposer)
        {
            base.WriteInteger(playerID);
            base.WriteInteger(effectID);
            base.WriteInteger(0);
        }
    }
}
