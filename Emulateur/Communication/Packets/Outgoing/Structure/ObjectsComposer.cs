using Butterfly.HabboHotel.Items;
using Butterfly.HabboHotel.Rooms;
using Butterfly.HabboHotel.Rooms.Wired;
using System;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ObjectsComposer : ServerPacket
    {
        public ObjectsComposer(Item[] Objects, Room Room)
            : base(ServerPacketHeader.ObjectsMessageComposer)
        {
            base.WriteInteger(1);

            base.WriteInteger(Room.RoomData.OwnerId);
            base.WriteString(Room.RoomData.OwnerName);

            base.WriteInteger(Objects.Length);
            foreach (Item Item in Objects)
            {
                WriteFloorItem(Item, Convert.ToInt32(Room.RoomData.OwnerId), Room.RoomData.HideWireds);
            }
        }

        public ObjectsComposer(ItemTemp[] Objects, Room Room)
            : base(ServerPacketHeader.ObjectsMessageComposer)
        {
            base.WriteInteger(1);

            base.WriteInteger(Room.RoomData.OwnerId);
            base.WriteString(Room.RoomData.OwnerName);

            base.WriteInteger(Objects.Length);
            foreach (ItemTemp Item in Objects)
            {
                WriteFloorItem(Item, Convert.ToInt32(Room.RoomData.OwnerId));
            }
        }

        private void WriteFloorItem(ItemTemp Item, int UserID)
        {

            base.WriteInteger(Item.Id);
            base.WriteInteger(Item.SpriteId);
            base.WriteInteger(Item.X);
            base.WriteInteger(Item.Y);
            base.WriteInteger(2);
            base.WriteString(String.Format("{0:0.00}", TextHandling.GetString(Item.Z)));
            base.WriteString(String.Empty);

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
                base.WriteString(Item.ExtraData);
            }

            base.WriteInteger(-1); // to-do: check
            base.WriteInteger(1); //(Item.GetBaseItem().Modes > 1) ? 1 : 0
            base.WriteInteger(UserID);
        }

        private void WriteFloorItem(Item Item, int UserID, bool HideWired)
        {

            base.WriteInteger(Item.Id);
            base.WriteInteger((HideWired && WiredUtillity.TypeIsWired(Item.GetBaseItem().InteractionType) && (Item.GetBaseItem().InteractionType != InteractionType.highscore && Item.GetBaseItem().InteractionType != InteractionType.highscorepoints)) ? 31294061 : Item.GetBaseItem().SpriteId);
            base.WriteInteger(Item.GetX);
            base.WriteInteger(Item.GetY);
            base.WriteInteger(Item.Rotation);
            base.WriteString(String.Format("{0:0.00}", TextHandling.GetString(Item.GetZ)));
            base.WriteString(String.Empty);

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
            base.WriteInteger(1); //(Item.GetBaseItem().Modes > 1) ? 1 : 0
            base.WriteInteger(UserID);
        }
    }
}
