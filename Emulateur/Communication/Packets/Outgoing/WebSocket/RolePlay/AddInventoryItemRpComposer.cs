using Butterfly.HabboHotel.Roleplay;

namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class AddInventoryItemRpComposer : ServerPacket
    {
        public AddInventoryItemRpComposer(RPItem Item, int pCount)
          : base(10)
        {
            base.WriteInteger(Item.Id);
            base.WriteString(Item.Name);
            base.WriteString(Item.Desc);
            base.WriteInteger((int)Item.Category);
            base.WriteInteger(pCount);
            base.WriteInteger(Item.UseType);
        }
    }
}
