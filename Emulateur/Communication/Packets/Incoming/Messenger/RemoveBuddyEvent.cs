using Butterfly.HabboHotel.GameClients;

namespace Butterfly.Communication.Packets.Incoming.Structure
{
    class RemoveBuddyEvent : IPacketEvent
    {
        public void Parse(GameClient Session, ClientPacket Packet)
        {
            if (Session.GetHabbo().GetMessenger() == null)
                return;
            int num = Packet.PopInt();
            for (int index = 0; index < num; ++index)
                Session.GetHabbo().GetMessenger().DestroyFriendship(Packet.PopInt());

        }
    }
}
