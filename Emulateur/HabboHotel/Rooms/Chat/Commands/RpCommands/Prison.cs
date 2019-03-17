﻿using Butterfly.HabboHotel.GameClients;
using Butterfly.HabboHotel.Roleplay.Player;
using System;

namespace Butterfly.HabboHotel.Rooms.Chat.Commands.Cmd
{
    class Prison : IChatCommand
    {
        public void Execute(GameClient Session, Room Room, RoomUser UserRoom, string[] Params)
        {
            if (Params.Length != 2)

            if (!Room.RpRoom || !Room.Pvp)
                return;
            if (Rp == null)
                return;
            if (RpTwo == null)
                return;
            {
                return;
            }
            {
                UserRoom.OnChat("*Tente d'arrêter " + TargetRoomUser.GetUsername() + "*");
                UserRoom.SendWhisperChat(ButterflyEnvironment.GetLanguageManager().TryGetValue("rp.prisonnotallowed", Session.Langue));
                return;
            }
                TargetRoomUser.Freeze = true;
                TargetRoomUser.FreezeEndCounter = 0;
                TargetRoomUser.IsLay = true;
                TargetRoomUser.UpdateNeeded = true;

            //UserRoom.ApplyEffect(737, true);

            if (UserRoom.FreezeEndCounter <= 2)
            {
                UserRoom.Freeze = true;
                UserRoom.FreezeEndCounter = 2;
            }
        }
    }
}