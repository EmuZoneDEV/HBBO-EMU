using Butterfly.HabboHotel.Roleplay;
using System.Collections.Generic;

namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class BuyItemsListComposer : ServerPacket
    {
        public BuyItemsListComposer(List<RPItem> ItemsBuy)
          : base(8)
        {
            base.WriteInteger(ItemsBuy.Count);

            foreach (RPItem Item in ItemsBuy)
            {
                base.WriteInteger(Item.Id);
                base.WriteString(Item.Name);
                base.WriteString(Item.Desc);
                base.WriteInteger(Item.Price);
            }
        }
    }
}