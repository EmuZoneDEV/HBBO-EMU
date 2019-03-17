using Butterfly.HabboHotel.GameClients;

namespace Butterfly.HabboHotel.Rooms.Chat.Commands.Cmd
{
    class RemoveBadge : IChatCommand
    {
        public void Execute(GameClient Session, Room Room, RoomUser UserRoom, string[] Params)
        {
            Room currentRoom = Session.GetHabbo().CurrentRoom;
            GameClient clientByUsername = ButterflyEnvironment.GetGame().GetClientManager().GetClientByUsername(Params[1]);
            if (clientByUsername != null && clientByUsername.GetHabbo() != null)
            {
                clientByUsername.GetHabbo().GetBadgeComponent().RemoveBadge(Params[2]);
                clientByUsername.SendPacket(clientByUsername.GetHabbo().GetBadgeComponent().Serialize());
            }
            else
                Session.SendNotification(ButterflyEnvironment.GetLanguageManager().TryGetValue("input.usernotfound", Session.Langue));

        }
    }
}
