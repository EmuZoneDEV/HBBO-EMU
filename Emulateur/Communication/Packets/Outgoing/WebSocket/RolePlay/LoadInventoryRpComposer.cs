using Butterfly.HabboHotel.Roleplay;
using Butterfly.HabboHotel.Roleplay.Player;
using System.Collections.Concurrent;

namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class LoadInventoryRpComposer : ServerPacket
    {
        public LoadInventoryRpComposer(ConcurrentDictionary<int, RolePlayInventoryItem> Items)
          : base(9)
        {
            base.WriteInteger(Items.Count);

            foreach(RolePlayInventoryItem Item in Items.Values)
            {
                RPItem RpItem = ButterflyEnvironment.GetGame().GetRoleplayManager().GetItemManager().GetItem(Item.ItemId);

                base.WriteInteger(Item.ItemId);
                base.WriteString(RpItem.Name);
                base.WriteString(RpItem.Desc);
                base.WriteInteger(Item.Count);
                base.WriteInteger((int)RpItem.Category);
                base.WriteInteger(RpItem.UseType);
            }
        }
    }
}