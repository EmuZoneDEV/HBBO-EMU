using Butterfly.HabboHotel.Items;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ObjectAddComposer : ServerPacket
    {
        public ObjectAddComposer(Item Item, string Username, int UserId)
            : base(ServerPacketHeader.ObjectAddMessageComposer)
        {
            base.WriteInteger(Item.Id);
            base.WriteInteger(Item.GetBaseItem().SpriteId);
            base.WriteInteger(Item.GetX);
            base.WriteInteger(Item.GetY);
            base.WriteInteger(Item.Rotation);
            base.WriteString(string.Format("{0:0.00}", TextHandling.GetString(Item.GetZ)));
            base.WriteString(string.Empty);

            if (Item.LimitedNo > 0)
            {
                base.WriteInteger(1);
                base.WriteInteger(256);
                base.WriteString(Item.ExtraData);
                base.WriteInteger(Item.LimitedNo);
                base.WriteInteger(Item.LimitedTot);
            }
            else
            {
                ItemBehaviourUtility.GenerateExtradata(Item, this);
            }

            base.WriteInteger(-1); // to-do: check
            base.WriteInteger(1);
            base.WriteInteger(UserId);
            base.WriteString(Username);
        }

        public ObjectAddComposer(ItemTemp Item)
            : base(ServerPacketHeader.ObjectAddMessageComposer)
        {
            base.WriteInteger(Item.Id);
            base.WriteInteger(Item.SpriteId); //ScriptId
            base.WriteInteger(Item.X);
            base.WriteInteger(Item.Y);
            base.WriteInteger(2);
            base.WriteString(string.Format("{0:0.00}", TextHandling.GetString(Item.Z)));
            base.WriteString("");

            if (Item.InteractionType == InteractionTypeTemp.RPITEM)
            {
                base.WriteInteger(0);
                base.WriteInteger(1);

                base.WriteInteger(5);

                base.WriteString("state");
                base.WriteString("0");
                base.WriteString("imageUrl");
                base.WriteString("https://swf.wibbo.me/items/" + Item.ExtraData + ".png");
                base.WriteString("offsetX");
                base.WriteString("-20");
                base.WriteString("offsetY");
                base.WriteString("10");
                base.WriteString("offsetZ");
                base.WriteString("10002");
            }
            else
            {
                base.WriteInteger(1);
                base.WriteInteger(0);
                base.WriteString(Item.ExtraData); //ExtraData
            }


            base.WriteInteger(-1); // to-do: check
            base.WriteInteger(1);
            base.WriteInteger(Item.VirtualUserId);
            base.WriteString("");
        }
    }
}
