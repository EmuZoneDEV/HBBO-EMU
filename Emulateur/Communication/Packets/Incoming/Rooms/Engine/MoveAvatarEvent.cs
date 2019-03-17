using Butterfly.HabboHotel.GameClients;
using Butterfly.HabboHotel.Rooms;

namespace Butterfly.Communication.Packets.Incoming.Structure
{
    class MoveAvatarEvent : IPacketEvent
    {
        public void Parse(GameClient Session, ClientPacket Packet)
        {
			Room currentRoom = Session.GetHabbo().CurrentRoom;
            {
                pX = User.SetX + (User.SetX - pX);
                pY = User.SetY + (User.SetY - pY);
            }
        }
    }
}