using Butterfly.HabboHotel.GameClients;

namespace Butterfly.HabboHotel.Rooms.Chat.Commands.Cmd
{
    class setzstop : IChatCommand
    {
        public void Execute(GameClient Session, Room Room, RoomUser UserRoom, string[] Params)
        {
            UserRoom.ConstruitZMode = false;
            Session.SendPacket(Room.GetGameMap().Model.SerializeRelativeHeightmap());
        }
    }
}
