using Butterfly.Communication.Packets.Outgoing;
using Butterfly.HabboHotel.GameClients;
using Butterfly.HabboHotel.HotelView;

namespace Butterfly.Communication.Packets.Incoming.Structure
{
    class GetPromoArticlesEvent : IPacketEvent
    {
        public void Parse(GameClient Session, ClientPacket Packet)
        {
            HotelViewManager currentView = ButterflyEnvironment.GetGame().GetHotelView();
        }
    }
}