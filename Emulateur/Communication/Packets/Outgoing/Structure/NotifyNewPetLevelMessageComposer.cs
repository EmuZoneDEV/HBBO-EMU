namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class NotifyNewPetLevelMessageComposer : ServerPacket
    {
        public NotifyNewPetLevelMessageComposer()
            : base(ServerPacketHeader.NotifyNewPetLevelMessageComposer)
        {
			
        }
    }
}