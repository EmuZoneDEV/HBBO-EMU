using Butterfly.HabboHotel.Pets;
using Butterfly.HabboHotel.Rooms;
using Butterfly.HabboHotel.Users;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class PetInformationComposer : ServerPacket
    {
        public PetInformationComposer(Pet Pet, bool IsRide = false)
            : base(ServerPacketHeader.PetInformationMessageComposer)
        {
            Room Room;

            if (!ButterflyEnvironment.GetGame().GetRoomManager().TryGetRoom(Pet.RoomId, out Room))
                return;

            base.WriteInteger(Pet.PetId);
            base.WriteString(Pet.Name);
            base.WriteInteger(Pet.Level);
            base.WriteInteger(Pet.MaxLevel);
            base.WriteInteger(Pet.Expirience);
            base.WriteInteger(Pet.ExpirienceGoal);
            base.WriteInteger(Pet.Energy);
            base.WriteInteger(Pet.MaxEnergy);
            base.WriteInteger(Pet.Nutrition);
            base.WriteInteger(Pet.MaxNutrition);
            base.WriteInteger(Pet.Respect);
            base.WriteInteger(Pet.OwnerId);
            base.WriteInteger(Pet.Age);
            base.WriteString(Pet.OwnerName);
            base.WriteInteger(1);//3 on hab
            base.WriteBoolean(Pet.Saddle > 0);
            base.WriteBoolean(IsRide);
            base.WriteInteger(0);//5 on hab
            base.WriteInteger(Pet.AnyoneCanRide ? 1 : 0); // Anyone can ride horse
            base.WriteInteger(0);
            base.WriteInteger(0);//512 on hab
            base.WriteInteger(0);//1536
            base.WriteInteger(0);//2560
            base.WriteInteger(0);//3584
            base.WriteInteger(0);
            base.WriteString("");
            base.WriteBoolean(false);
            base.WriteInteger(-1);//255 on hab
            base.WriteInteger(-1);
            base.WriteInteger(-1);
            base.WriteBoolean(false);
        }

        public PetInformationComposer(Habbo Habbo)
            : base(ServerPacketHeader.PetInformationMessageComposer)
        {
            base.WriteInteger(Habbo.Id);
            base.WriteString(Habbo.Username);
            base.WriteInteger(Habbo.Rank);
            base.WriteInteger(10);
            base.WriteInteger(0);
            base.WriteInteger(0);
            base.WriteInteger(100);
            base.WriteInteger(100);
            base.WriteInteger(100);
            base.WriteInteger(100);
            base.WriteInteger(Habbo.Respect);
            base.WriteInteger(Habbo.Id);
            base.WriteInteger(0);//account created
            base.WriteString(Habbo.Username);
            base.WriteInteger(1);//3 on hab
            base.WriteBoolean(false);
            base.WriteBoolean(false);
            base.WriteInteger(0);//5 on hab
            base.WriteInteger(0); // Anyone can ride horse
            base.WriteInteger(0);
            base.WriteInteger(0);//512 on hab
            base.WriteInteger(0);//1536
            base.WriteInteger(0);//2560
            base.WriteInteger(0);//3584
            base.WriteInteger(0);
            base.WriteString("");
            base.WriteBoolean(false);
            base.WriteInteger(-1);//255 on hab
            base.WriteInteger(-1);
            base.WriteInteger(-1);
            base.WriteBoolean(false);
        }
    }
}
