using Butterfly.HabboHotel.Roleplay;
using System.Collections.Generic;

namespace Butterfly.Communication.Packets.Outgoing.WebSocket.Troc
{
    class RpTrocUpdateItemsComposer : ServerPacket
    {
        public RpTrocUpdateItemsComposer(int UserId, Dictionary<int, int> Items)
          : base(17)
        {
            base.WriteInteger(UserId);
            base.WriteInteger(Items.Count);

            foreach(KeyValuePair<int, int> Item in Items)
            {
                RPItem RpItem = ButterflyEnvironment.GetGame().GetRoleplayManager().GetItemManager().GetItem(Item.Key);

                base.WriteInteger(Item.Key);
                base.WriteString((RpItem == null) ? "" : RpItem.Name);
                base.WriteString((RpItem == null) ? "" : RpItem.Desc);
                base.WriteInteger(Item.Value);
            }
        }
    }
}
