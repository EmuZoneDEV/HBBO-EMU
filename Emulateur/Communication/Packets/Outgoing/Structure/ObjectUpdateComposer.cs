using Butterfly.HabboHotel.Items;
using Butterfly.HabboHotel.Rooms.Wired;
using System;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class ObjectUpdateComposer : ServerPacket
    {
        public ObjectUpdateComposer(Item Item, int UserId, bool HideWired = false)
            : base(ServerPacketHeader.ObjectUpdateMessageComposer)
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
            base.WriteInteger(UserId);
        }
    }
}
