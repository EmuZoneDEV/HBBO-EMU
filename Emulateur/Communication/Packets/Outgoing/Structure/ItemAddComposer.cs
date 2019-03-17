using Butterfly.HabboHotel.Items;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ItemAddComposer : ServerPacket
    {
        public ItemAddComposer(Item Item, string Username, int UserID)
            : base(ServerPacketHeader.ItemAddMessageComposer)
        {
            base.WriteString(Item.Id.ToString());
            base.WriteInteger(Item.GetBaseItem().SpriteId);
            base.WriteString(Item.wallCoord != null ? Item.wallCoord : string.Empty);

            ItemBehaviourUtility.GenerateWallExtradata(Item, this);

            base.WriteInteger(-1);
            base.WriteInteger((Item.GetBaseItem().Modes > 1) ? 1 : 0); // Type New R63 ('use bottom')
            base.WriteInteger(UserID);
            base.WriteString(Username);
        }
    }
}
