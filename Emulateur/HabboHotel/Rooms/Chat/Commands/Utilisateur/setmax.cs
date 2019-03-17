using Butterfly.HabboHotel.GameClients;

namespace Butterfly.HabboHotel.Rooms.Chat.Commands.Cmd
{
    class setmax : IChatCommand
    {
        public void Execute(GameClient Session, Room Room, RoomUser UserRoom, string[] Params)
        {
            Room currentRoom1 = Session.GetHabbo().CurrentRoom;
            Room currentRoom2 = Session.GetHabbo().CurrentRoom;
            int num = currentRoom2.Id;

            int MaxUsers = 0;
            int.TryParse(Params[1], out MaxUsers);
            if (MaxUsers > 75 && Session.GetHabbo().Rank < 5 || MaxUsers > 1000 || MaxUsers <= 0)
                currentRoom2.SetMaxUsers(75);
            else
                currentRoom2.SetMaxUsers(MaxUsers);

        }
    }
}
