namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class LoveLockDialogueSetLockedMessageComposer : ServerPacket
    {
        public LoveLockDialogueSetLockedMessageComposer(int ItemId)
            : base(ServerPacketHeader.LoveLockDialogueSetLockedMessageComposer)
        {
            base.WriteInteger(ItemId);
        }
    }
}
