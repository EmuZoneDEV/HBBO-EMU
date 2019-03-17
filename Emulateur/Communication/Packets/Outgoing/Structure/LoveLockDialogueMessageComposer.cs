namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class LoveLockDialogueMessageComposer : ServerPacket
    {
        public LoveLockDialogueMessageComposer(int ItemId)
            : base(ServerPacketHeader.LoveLockDialogueMessageComposer)
        {
            base.WriteInteger(ItemId);
            base.WriteBoolean(true);
        }
    }
}
