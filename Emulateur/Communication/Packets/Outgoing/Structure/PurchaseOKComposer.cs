using Butterfly.HabboHotel.Catalog;
using Butterfly.HabboHotel.Items;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class PurchaseOKComposer : ServerPacket
    {
        public PurchaseOKComposer(CatalogItem Item, ItemData BaseItem)
            : base(ServerPacketHeader.PurchaseOKMessageComposer)
        {
            base.WriteInteger(BaseItem.Id);
            base.WriteString(BaseItem.ItemName);
            base.WriteBoolean(false);
            base.WriteInteger(Item.CostCredits);
            base.WriteInteger(Item.CostDuckets);
            base.WriteInteger(0);
            base.WriteBoolean(true);
            base.WriteInteger(1);
            base.WriteString(BaseItem.Type.ToString().ToLower());
            base.WriteInteger(BaseItem.SpriteId);
            base.WriteString("");
            base.WriteInteger(1);
            base.WriteInteger(0);
            base.WriteString("");
            base.WriteInteger(1);
        }

        public PurchaseOKComposer()
            : base(ServerPacketHeader.PurchaseOKMessageComposer)
        {
            base.WriteInteger(0);
            base.WriteString("");
            base.WriteBoolean(false);
            base.WriteInteger(0);
            base.WriteInteger(0);
            base.WriteInteger(0);
            base.WriteBoolean(true);
            base.WriteInteger(1);
            base.WriteString("s");
            base.WriteInteger(0);
            base.WriteString("");
            base.WriteInteger(1);
            base.WriteInteger(0);
            base.WriteString("");
            base.WriteInteger(1);
        }
    }
}
