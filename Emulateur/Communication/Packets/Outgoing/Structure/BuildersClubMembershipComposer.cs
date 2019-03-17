namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class BuildersClubMembershipComposer : ServerPacket
    {
        public BuildersClubMembershipComposer()
            : base(ServerPacketHeader.BuildersClubMembershipMessageComposer)
        {
            base.WriteInteger(99999999);
            base.WriteInteger(100);
            base.WriteInteger(2);
            base.WriteInteger(99999999);
        }
    }
}
