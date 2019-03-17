using Butterfly.HabboHotel.GameClients;
using Butterfly.HabboHotel.Rooms;
using System;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class GetGuestRoomResultComposer : ServerPacket
    {
        public GetGuestRoomResultComposer(GameClient Session, RoomData Data, Boolean isLoading, Boolean checkEntry)
            : base(ServerPacketHeader.GetGuestRoomResultMessageComposer)
        {
            base.WriteBoolean(isLoading);
            base.WriteInteger(Data.Id);
            base.WriteString(Data.Name);
            base.WriteInteger(Data.OwnerId);
            base.WriteString(Data.OwnerName);
            base.WriteInteger((Session.GetHabbo().IsTeleporting) ? 0 : Data.State);
            base.WriteInteger(Data.UsersNow);
            base.WriteInteger(Data.UsersMax);
            base.WriteString(Data.Description);
            base.WriteInteger(Data.TrocStatus);
            base.WriteInteger(Data.Score);
            base.WriteInteger(0);//Top rated room rank.
            base.WriteInteger(Data.Category);

            base.WriteInteger(Data.Tags.Count);
            foreach (string Tag in Data.Tags)
            {
                base.WriteString(Tag);
            }

           
            if (Data.Group != null)
            {
                base.WriteInteger(58);//What?
                base.WriteInteger(Data.Group == null ? 0 : Data.Group.Id);
                base.WriteString(Data.Group == null ? "" : Data.Group.Name);
                base.WriteString(Data.Group == null ? "" : Data.Group.Badge);
            }
            else
            {
                base.WriteInteger(56);//What?
            }


            base.WriteBoolean(checkEntry);
            base.WriteBoolean(false);
            base.WriteBoolean(false);
            base.WriteBoolean(false);

            base.WriteInteger(Data.MuteFuse); // who can mute
            base.WriteInteger(Data.WhoCanKick); // who can kick
            base.WriteInteger(Data.BanFuse); // who can ban

            base.WriteBoolean((Session != null) ? Data.OwnerName.ToLower() != Session.GetHabbo().Username.ToLower() : false);
            base.WriteInteger(Data.ChatType);  //ChatMode, ChatSize, ChatSpeed, HearingDistance, ExtraFlood is the order.
            base.WriteInteger(Data.ChatBalloon);
            base.WriteInteger(Data.ChatSpeed);
            base.WriteInteger(Data.ChatMaxDistance);
            base.WriteInteger(Data.ChatFloodProtection);
        }
    }
}
