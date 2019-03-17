using Butterfly.HabboHotel.Pets;
using Butterfly.HabboHotel.Rooms;
using Butterfly.HabboHotel.Users;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class RespectPetNotificationComposer : ServerPacket
    {
        public RespectPetNotificationComposer(Pet Pet)
            : base(ServerPacketHeader.RespectPetNotificationMessageComposer)
        {
            //TODO: Structure
            base.WriteInteger(Pet.VirtualId);
            base.WriteInteger(Pet.VirtualId);
            base.WriteInteger(Pet.PetId);//Pet Id, 100%
            base.WriteString(Pet.Name);
            base.WriteInteger(0);
            base.WriteInteger(0);
            base.WriteString(Pet.Color);
            base.WriteInteger(0);
            base.WriteInteger(0);//Count - 3 ints.
            base.WriteInteger(1);
        }

        public RespectPetNotificationComposer(Habbo Habbo, RoomUser User)
            : base(ServerPacketHeader.RespectPetNotificationMessageComposer)
        {
            //TODO: Structure
            base.WriteInteger(User.VirtualId);
            base.WriteInteger(User.VirtualId);
            base.WriteInteger(Habbo.Id);//Pet Id, 100%
            base.WriteString(Habbo.Username);
            base.WriteInteger(0);
            base.WriteInteger(0);
            base.WriteString("FFFFFF");//Yeah..
            base.WriteInteger(0);
            base.WriteInteger(0);//Count - 3 ints.
            base.WriteInteger(1);
        }
    }
}
