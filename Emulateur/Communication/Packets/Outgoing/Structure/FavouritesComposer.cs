using Butterfly.HabboHotel.Rooms;
using System.Collections.Generic;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class FavouritesComposer : ServerPacket
    {
        public FavouritesComposer(List<RoomData> favouriteIDs)
            : base(ServerPacketHeader.FavouritesMessageComposer)
        {
            base.WriteInteger(30);
            base.WriteInteger(favouriteIDs.Count);

            foreach (RoomData Room in favouriteIDs)
            {
                base.WriteInteger(Room.Id);
            }
        }
    }
}
