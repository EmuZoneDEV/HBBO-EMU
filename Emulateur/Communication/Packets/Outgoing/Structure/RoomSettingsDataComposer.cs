using Butterfly.HabboHotel.Rooms;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class RoomSettingsDataComposer : ServerPacket
    {
        public RoomSettingsDataComposer(RoomData Room)
            : base(ServerPacketHeader.RoomSettingsDataMessageComposer)
        {
            base.WriteInteger(Room.Id);
            base.WriteString(Room.Name);
            base.WriteString(Room.Description);
            base.WriteInteger(Room.State);
            base.WriteInteger(Room.Category); 
            base.WriteInteger(Room.UsersMax);
            base.WriteInteger(((Room.Model.MapSizeX * Room.Model.MapSizeY) > 100) ? 50 : 25);

            base.WriteInteger(Room.Tags.Count);
            foreach (string Tag in Room.Tags.ToArray())
            {
                base.WriteString(Tag);
            }

            base.WriteInteger(Room.TrocStatus); //Trade
            base.WriteInteger(Room.AllowPets ? 1 : 0); // allows pets in room - pet system lacking, so always off
            base.WriteInteger(Room.AllowPetsEating ? 1 : 0);// allows pets to eat your food - pet system lacking, so always off
            base.WriteInteger(Room.AllowWalkthrough ? 1 : 0);
            base.WriteInteger(Room.Hidewall ? 1 : 0);
            base.WriteInteger(Room.WallThickness);
            base.WriteInteger(Room.FloorThickness);

            base.WriteInteger(Room.ChatType);//Chat mode
            base.WriteInteger(Room.ChatBalloon);//Chat size
            base.WriteInteger(Room.ChatSpeed);//Chat speed
            base.WriteInteger(Room.ChatMaxDistance);//Hearing Distance
            base.WriteInteger(Room.ChatFloodProtection);//Additional Flood

            base.WriteBoolean(true);

            base.WriteInteger(Room.MuteFuse); // who can mute
            base.WriteInteger(Room.WhoCanKick); // who can kick
            base.WriteInteger(Room.BanFuse); // who can ban
        }
    }
}
