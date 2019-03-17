using Butterfly.Communication.Packets.Outgoing.Structure;
using Butterfly.HabboHotel.GameClients;

namespace Butterfly.HabboHotel.Rooms.Chat.Commands.Cmd
            //if (UserRoom.team != Team.none || UserRoom.InGame)
                //return;

            if (Room.RpRoom && !Room.CheckRights(Session))
            {
                RoomUser Bot = Room.GetRoomUserManager().GetBotByName(Username);
                if (Bot == null || Bot.BotData == null)
                    return;

                Session.GetHabbo().Gender = Bot.BotData.Gender;
                Session.GetHabbo().Look = Bot.BotData.Look;
            }
            else
            {

                if (clientByUsername.GetHabbo().PremiumProtect && !Session.GetHabbo().HasFuse("fuse_mod"))
                {
                    UserRoom.SendWhisperChat(ButterflyEnvironment.GetLanguageManager().TryGetValue("premium.notallowed", Session.Langue));
                    return;
                }

                Session.GetHabbo().Gender = clientByUsername.GetHabbo().Gender;
                Session.GetHabbo().Look = clientByUsername.GetHabbo().Look;
            }