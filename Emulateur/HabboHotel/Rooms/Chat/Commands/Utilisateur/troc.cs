using Butterfly.HabboHotel.GameClients;

namespace Butterfly.HabboHotel.Rooms.Chat.Commands.Cmd
{
    class troc : IChatCommand
    {
        public void Execute(GameClient Session, Room Room, RoomUser UserRoom, string[] Params)
        {
            if (Session.GetHabbo().AcceptTrading)
            {
                Session.GetHabbo().AcceptTrading = false;
                UserRoom.SendWhisperChat(ButterflyEnvironment.GetLanguageManager().TryGetValue("cmd.troc.true", Session.Langue));
            }
            else
            {
                Session.GetHabbo().AcceptTrading = true;
                UserRoom.SendWhisperChat(ButterflyEnvironment.GetLanguageManager().TryGetValue("cmd.troc.false", Session.Langue));
            }

        }
    }
}
