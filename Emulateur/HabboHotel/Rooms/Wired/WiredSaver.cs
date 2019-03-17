using Butterfly.HabboHotel.GameClients;
using Butterfly.HabboHotel.Items;
using Butterfly.HabboHotel.Rooms.Wired.WiredHandlers;
using Butterfly.HabboHotel.Rooms.Wired.WiredHandlers.Conditions;
using Butterfly.HabboHotel.Rooms.Wired.WiredHandlers.Effects;
using Butterfly.HabboHotel.Rooms.Wired.WiredHandlers.Interfaces;
using Butterfly.HabboHotel.Rooms.Wired.WiredHandlers.Triggers;
using Butterfly.Communication.Packets.Outgoing;
using Butterfly.Database.Interfaces;
using Butterfly.Communication.Packets.Incoming;

using System.Collections.Generic;
using Butterfly.HabboHotel.Rooms.Map.Movement;

namespace Butterfly.HabboHotel.Rooms.Wired
{
    public class WiredSaver
    {
        public static void HandleDefaultSave(int itemID, Room room, Item roomItem)
        {
            if (roomItem == null)
                return;

            switch (roomItem.GetBaseItem().InteractionType)
            {
                #region SaveDefaultTrigger
                case InteractionType.triggertimer:
                    int cycleCount = 0;
                    WiredSaver.HandleTriggerSave(new Timer(roomItem, room.GetWiredHandler(), cycleCount, room.GetGameManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerroomenter:
                    string userName = string.Empty;
                    WiredSaver.HandleTriggerSave(new EntersRoom(roomItem, room.GetWiredHandler(), room.GetRoomUserManager(), !string.IsNullOrEmpty(userName), userName), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggercollision:
                    WiredSaver.HandleTriggerSave(new Collision(roomItem, room.GetWiredHandler(), room.GetRoomUserManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggergameend:
                    WiredSaver.HandleTriggerSave(new GameEnds(roomItem, room.GetWiredHandler(), room.GetGameManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggergamestart:
                    WiredSaver.HandleTriggerSave(new GameStarts(roomItem, room.GetWiredHandler(), room.GetGameManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerrepeater:
                    int cyclesRequired = 0;
                    WiredSaver.HandleTriggerSave(new Repeater(room.GetWiredHandler(), roomItem, cyclesRequired), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerrepeaterlong:
                    int cyclesRequiredlong = 0;
                    WiredSaver.HandleTriggerSave(new Repeaterlong(room.GetWiredHandler(), roomItem, cyclesRequiredlong), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggeronusersay:
                    bool flag = false;
                    string triggerMessage = string.Empty;
                    WiredSaver.HandleTriggerSave(new UserSays(roomItem, room.GetWiredHandler(), !flag, triggerMessage, room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggercommand:
                    WiredSaver.HandleTriggerSave(new UserCommand(roomItem, room.GetWiredHandler(), room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_trg_bot_reached_avtr:
                    WiredSaver.HandleTriggerSave(new BotReadchedAvatar(roomItem, room.GetWiredHandler(), ""), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggercollisionuser:
                    WiredSaver.HandleTriggerSave(new UserCollision(roomItem, room.GetWiredHandler(), room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerscoreachieved:
                    int scoreLevel = 0;
                    WiredSaver.HandleTriggerSave(new ScoreAchieved(roomItem, room.GetWiredHandler(), scoreLevel, room.GetGameManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerstatechanged:
                    List<Item> items1 = new List<Item>();
                    int delay1 = 0;
                    WiredSaver.HandleTriggerSave(new SateChanged(room.GetWiredHandler(), roomItem, items1, delay1), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerwalkonfurni:
                    List<Item> targetItems1 = new List<Item>();
                    int requiredCycles1 = 0;
                    WiredSaver.HandleTriggerSave(new WalksOnFurni(roomItem, room.GetWiredHandler(), targetItems1, requiredCycles1), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerwalkofffurni:
                    List<Item> targetItems2 = new List<Item>();
                    int requiredCycles2 = 0;
                    WiredSaver.HandleTriggerSave(new WalksOffFurni(roomItem, room.GetWiredHandler(), targetItems2, requiredCycles2), room.GetWiredHandler(), room, roomItem);
                    break;
                #endregion
                #region SauveDefaultAction
                case InteractionType.actiongivescore:
                    WiredSaver.HandleTriggerSave(new GiveScore(0, 0, room.GetGameManager(), itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_give_score_tm:
                    WiredSaver.HandleTriggerSave(new GiveScoreTeam(0, 0, 0, room.GetGameManager(), itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionposreset:
                    WiredSaver.HandleTriggerSave(new PositionReset(new List<Item>(), 0, room.GetRoomItemHandler(), room.GetWiredHandler(), itemID, 0, 0, 0), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionmoverotate:
                    WiredSaver.HandleTriggerSave(new MoveRotate(MovementState.none, RotationState.none, new List<Item>(), 0, room, room.GetWiredHandler(), itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionresettimer:
                    int delay2 = 0;
                    WiredSaver.HandleTriggerSave(new TimerReset(room, room.GetWiredHandler(), delay2, itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.highscore:
                    WiredSaver.HandleTriggerSave(new HighScore(roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.highscorepoints:
                    WiredSaver.HandleTriggerSave(new HighScorePoints(roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionshowmessage:
                    WiredSaver.HandleTriggerSave(new ShowMessage(string.Empty, room.GetWiredHandler(), itemID, 0), room.GetWiredHandler(), room, roomItem);
                    break;
                //case InteractionType.actiongivereward:
                //WiredSaver.HandleTriggerSave(new GiveReward(string.Empty, room.GetWiredHandler(), itemID), room.GetWiredHandler(), room, roomItem);
                //break;
                case InteractionType.superwired:
                    WiredSaver.HandleTriggerSave(new SuperWired(string.Empty, 0, false, false, room.GetWiredHandler(), itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionkickuser:
                    WiredSaver.HandleTriggerSave(new KickUser(string.Empty, room.GetWiredHandler(), itemID, room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionteleportto:
                    List<Item> items3 = new List<Item>();
                    int delay3 = 0;
                    WiredSaver.HandleTriggerSave(new TeleportToItem(room.GetGameMap(), room.GetWiredHandler(), items3, delay3, itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_endgame_team:
                    List<Item> itemstpteam = new List<Item>();
                    WiredSaver.HandleTriggerSave(new TeamGameOver(1, itemID, room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actiontogglestate:
                    List<Item> items4 = new List<Item>();
                    int delay4 = 0;
                    WiredSaver.HandleTriggerSave(new ToggleItemState(room.GetGameMap(), room.GetWiredHandler(), items4, delay4, roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_call_stacks:
                    WiredSaver.HandleTriggerSave(new ExecutePile(new List<Item>(), 0, room.GetWiredHandler(), roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionflee:
                    List<Item> itemsflee = new List<Item>();
                    WiredSaver.HandleTriggerSave(new Escape(itemsflee, room, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionchase:
                    List<Item> itemschase = new List<Item>();
                    WiredSaver.HandleTriggerSave(new Chase(itemschase, room, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.collisioncase:
                    List<Item> itemscollision = new List<Item>();
                    WiredSaver.HandleTriggerSave(new CollisionCase(itemscollision, room, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionmovetodir:
                    WiredSaver.HandleTriggerSave(new MoveToDir(new List<Item>(), room, room.GetWiredHandler(), roomItem.Id, MovementDirection.none, WhenMovementBlock.none), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_clothes:
                    WiredSaver.HandleTriggerSave(new BotClothes("", "", room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_teleport:
                    WiredSaver.HandleTriggerSave(new BotTeleport("", new List<Item>(), room.GetGameMap(), room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_follow_avatar:
                    WiredSaver.HandleTriggerSave(new BotFollowAvatar("", false, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_give_handitem:
                    WiredSaver.HandleTriggerSave(new BotGiveHanditem("", room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_move:
                    WiredSaver.HandleTriggerSave(new BotMove("", new List<Item>(), room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_user_move:
                    WiredSaver.HandleTriggerSave(new UserMove(new List<Item>(), 0, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_talk_to_avatar:
                    WiredSaver.HandleTriggerSave(new BotTalkToAvatar("", "", false, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_talk:
                    WiredSaver.HandleTriggerSave(new BotTalk("", "", false, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_leave_team:
                    WiredSaver.HandleTriggerSave(new TeamLeave(itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_join_team:
                    WiredSaver.HandleTriggerSave(new TeamJoin(1, itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                #endregion
                #region SaveDefaultCondition
                case InteractionType.superwiredcondition:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new SuperWiredCondition(roomItem, "", false), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionfurnishaveusers:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniHasUser(roomItem, new List<Item>()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionfurnishavenousers:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniHasNoUser(roomItem, new List<Item>()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionstatepos:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniStatePosMatch(roomItem, new List<Item>(), 0, 0, 0), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_stuff_is:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniStuffIs(roomItem, new List<Item>()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_not_stuff_is:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniNotStuffIs(roomItem, new List<Item>()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionstateposNegative:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniStatePosMatchNegative(roomItem, new List<Item>(), 0, 0, 0), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditiontimelessthan:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new LessThanTimer(0, room, roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditiontimemorethan:
                    List<Item> items8 = new List<Item>();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new MoreThanTimer(0, room, roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditiontriggeronfurni:
                    List<Item> items9 = new List<Item>();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new TriggerUserIsOnFurni(roomItem, items9), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditiontriggeronfurniNegative:
                    List<Item> items12 = new List<Item>();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new TriggerUserIsOnFurniNegative(roomItem, items12), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionhasfurnionfurni:
                    List<Item> items11 = new List<Item>();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new HasFurniOnFurni(roomItem, items11), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionhasfurnionfurniNegative:
                    List<Item> items14 = new List<Item>();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new HasFurniOnFurniNegative(roomItem, items14), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionactoringroup:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new HasUserInGroup(roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionnotingroup:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new HasUserNotInGroup(roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_actor_in_team:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new ActorInTeam(roomItem.Id, 1), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_not_in_team:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new ActorNotInTeam(roomItem.Id, 1), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_not_user_count:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new RoomUserNotCount(roomItem, 1, 1), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_user_count_in:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new RoomUserCount(roomItem, 1, 1), room.GetWiredHandler(), room, roomItem);
                    break;
                #endregion
            }
        }

        public static void HandleSave(GameClient Session, int itemID, Room room, ClientPacket clientMessage)
        {
            Item roomItem = room.GetRoomItemHandler().GetItem(itemID);
            if (roomItem == null)
                return;
            if (roomItem.WiredHandler != null)
            {
                roomItem.WiredHandler.Dispose();
                roomItem.WiredHandler = null;
            }

            switch (roomItem.GetBaseItem().InteractionType)
            {
                #region Trigger
                case InteractionType.triggertimer:
                    clientMessage.PopInt();
                    int cycleCount = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new Timer(roomItem, room.GetWiredHandler(), cycleCount, room.GetGameManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerroomenter:
                    clientMessage.PopInt();
                    string userName = clientMessage.PopString();
                    WiredSaver.HandleTriggerSave(new EntersRoom(roomItem, room.GetWiredHandler(), room.GetRoomUserManager(), !string.IsNullOrEmpty(userName), userName), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggercollision:
                    WiredSaver.HandleTriggerSave(new Collision(roomItem, room.GetWiredHandler(), room.GetRoomUserManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggergameend:
                    WiredSaver.HandleTriggerSave(new GameEnds(roomItem, room.GetWiredHandler(), room.GetGameManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggergamestart:
                    WiredSaver.HandleTriggerSave(new GameStarts(roomItem, room.GetWiredHandler(), room.GetGameManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerrepeater:
                    clientMessage.PopInt();
                    int cyclesRequired = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new Repeater(room.GetWiredHandler(), roomItem, cyclesRequired), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerrepeaterlong:
                    clientMessage.PopInt();
                    int cyclesRequiredlong = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new Repeaterlong(room.GetWiredHandler(), roomItem, cyclesRequiredlong), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggeronusersay:
                    clientMessage.PopInt();
                    bool isOwnerOnly = clientMessage.PopInt() == 1;
                    string triggerMessage = clientMessage.PopString();
                    WiredSaver.HandleTriggerSave(new UserSays(roomItem, room.GetWiredHandler(), isOwnerOnly, triggerMessage, room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggercommand:
                    WiredSaver.HandleTriggerSave(new UserCommand(roomItem, room.GetWiredHandler(), room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_trg_bot_reached_avtr:
                    clientMessage.PopInt();

                    string NameBotReached = clientMessage.PopString();
                    WiredSaver.HandleTriggerSave(new BotReadchedAvatar(roomItem, room.GetWiredHandler(), NameBotReached), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggercollisionuser:
                    WiredSaver.HandleTriggerSave(new UserCollision(roomItem, room.GetWiredHandler(), room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerscoreachieved:
                    clientMessage.PopInt();
                    int scoreLevel = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new ScoreAchieved(roomItem, room.GetWiredHandler(), scoreLevel, room.GetGameManager()), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerstatechanged:
                    clientMessage.PopInt();
                    clientMessage.PopBoolean();
                    clientMessage.PopBoolean();
                    List<Item> items1 = WiredSaver.GetItems(clientMessage, room, itemID);
                    int delay1 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new SateChanged(room.GetWiredHandler(), roomItem, items1, delay1), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerwalkonfurni:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    List<Item> items2 = WiredSaver.GetItems(clientMessage, room, itemID);
                    int requiredCycles1 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new WalksOnFurni(roomItem, room.GetWiredHandler(), items2, requiredCycles1), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.triggerwalkofffurni:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    List<Item> items3 = WiredSaver.GetItems(clientMessage, room, itemID);
                    int requiredCycles2 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new WalksOffFurni(roomItem, room.GetWiredHandler(), items3, requiredCycles2), room.GetWiredHandler(), room, roomItem);
                    break;
                #endregion
                #region Action
                case InteractionType.actiongivescore:
                    clientMessage.PopInt();
                    int scoreToGive = clientMessage.PopInt();
                    int maxCountPerGame = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new GiveScore(maxCountPerGame, scoreToGive, room.GetGameManager(), itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_give_score_tm:
                    clientMessage.PopInt();
                    int scoreToGive2 = clientMessage.PopInt();
                    int maxCountPerGame2 = clientMessage.PopInt();
                    int TeamId = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new GiveScoreTeam(TeamId, maxCountPerGame2, scoreToGive2, room.GetGameManager(), itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionposreset:
                    clientMessage.PopInt();
                    int EtatActuel = clientMessage.PopInt();
                    int DirectionActuel = clientMessage.PopInt();
                    int PositionActuel = clientMessage.PopInt();
                    clientMessage.PopBoolean();
                    clientMessage.PopBoolean();
                    
                    List<Item> itemsposrest = WiredSaver.GetItems(clientMessage, room, itemID);
                    int requiredCyclesposrest = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new PositionReset(itemsposrest, requiredCyclesposrest, room.GetRoomItemHandler(), room.GetWiredHandler(), itemID, EtatActuel, DirectionActuel, PositionActuel), room.GetWiredHandler(), room, roomItem);

                    break;
                case InteractionType.actionmoverotate:
                    clientMessage.PopInt();
                    MovementState movement = (MovementState)clientMessage.PopInt();
                    RotationState rotation = (RotationState)clientMessage.PopInt();
                    clientMessage.PopBoolean();
                    clientMessage.PopBoolean();
                    List<Item> items4 = WiredSaver.GetItems(clientMessage, room, itemID);
                    int delay2 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new MoveRotate(movement, rotation, items4, delay2, room, room.GetWiredHandler(), itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionresettimer:
                    clientMessage.PopInt();
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    int delay3 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new TimerReset(room, room.GetWiredHandler(), delay3, itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.highscore:
                case InteractionType.highscorepoints:

                    break;
                case InteractionType.actionshowmessage:
                    clientMessage.PopInt();
                    string MessageWired = clientMessage.PopString();
                    int CountItemMessage = clientMessage.PopInt();
                    int DelayMessage = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new ShowMessage(MessageWired, room.GetWiredHandler(), itemID, DelayMessage), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.superwired:
                    clientMessage.PopInt();
                    string MessageSuperWired = clientMessage.PopString();
                    int CountItemSuperWired = clientMessage.PopInt();
                    int DelaySuperWired = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new SuperWired(MessageSuperWired, DelaySuperWired, Session.GetHabbo().HasFuse("fuse_superwired"), Session.GetHabbo().Rank > 7, room.GetWiredHandler(), itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actiongivereward:
                    if (!Session.GetHabbo().HasFuse("fuse_superwired"))
                    {
                        return;
                    }
                    //clientMessage.PopInt();
                    //WiredSaver.HandleTriggerSave((IWiredTrigger)new GiveReward(clientMessage.PopString(), room.GetWiredHandler(), itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionkickuser:
                    clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new KickUser(clientMessage.PopString(), room.GetWiredHandler(), itemID, room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionteleportto:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    List<Item> items6 = WiredSaver.GetItems(clientMessage, room, itemID);
                    int delay4 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new TeleportToItem(room.GetGameMap(), room.GetWiredHandler(), items6, delay4, itemID), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_endgame_team:
                    clientMessage.PopInt();
                    int TeamId3 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new TeamGameOver(TeamId3, roomItem.Id, room), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actiontogglestate:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    List<Item> items7 = WiredSaver.GetItems(clientMessage, room, itemID);
                    int delay5 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new ToggleItemState(room.GetGameMap(), room.GetWiredHandler(), items7, delay5, roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_call_stacks:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    List<Item> itemsExecute = WiredSaver.GetItems(clientMessage, room, itemID);
                    int StackDeley = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new ExecutePile(itemsExecute, StackDeley, room.GetWiredHandler(), roomItem), room.GetWiredHandler(), room, roomItem);

                    break;
                case InteractionType.actionflee:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    List<Item> itemsflee = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave(new Escape(itemsflee, room, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionchase:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    List<Item> itemschase = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave(new Chase(itemschase, room, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.collisioncase:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    List<Item> itemscollision = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave(new CollisionCase(itemscollision, room, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.actionmovetodir:
                    clientMessage.PopInt();

                    MovementDirection StarDirect = (MovementDirection)clientMessage.PopInt();
                    WhenMovementBlock WhenBlock = (WhenMovementBlock)clientMessage.PopInt();

                    clientMessage.PopBoolean();
                    clientMessage.PopBoolean();
                    
                    List<Item> itemsmovetodir = WiredSaver.GetItems(clientMessage, room, itemID);
                    int delaymovetodir = clientMessage.PopInt();

                    WiredSaver.HandleTriggerSave(new MoveToDir(itemsmovetodir, room, room.GetWiredHandler(), roomItem.Id, StarDirect, WhenBlock), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_clothes:
                    clientMessage.PopInt();

                    string NameAndLook = clientMessage.PopString();

                    string[] SplieNAL = NameAndLook.Split('\t');
                    if (SplieNAL.Length != 2)
                        break;

                    WiredSaver.HandleTriggerSave(new BotClothes(SplieNAL[0], SplieNAL[1], room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_teleport:
                    clientMessage.PopInt();

                    string NameBot = clientMessage.PopString();
                    
                    List<Item> itemsbotteleport = WiredSaver.GetItems(clientMessage, room, itemID);

                    WiredSaver.HandleTriggerSave(new BotTeleport(NameBot, itemsbotteleport, room.GetGameMap(), room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_follow_avatar:
                    clientMessage.PopInt();

                    bool IsFollow = (clientMessage.PopInt() == 1);
                    string NameBotFollow = clientMessage.PopString();

                    WiredSaver.HandleTriggerSave(new BotFollowAvatar(NameBotFollow, IsFollow, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_give_handitem:
                    clientMessage.PopInt();

                    WiredSaver.HandleTriggerSave(new BotGiveHanditem("", room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_move:
                    clientMessage.PopInt();

                    string NameBotMove = clientMessage.PopString();
                    
                    List<Item> itemsbotMove = WiredSaver.GetItems(clientMessage, room, itemID);

                    WiredSaver.HandleTriggerSave(new BotMove(NameBotMove, itemsbotMove, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_user_move:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    List<Item> itemsUserMove = WiredSaver.GetItems(clientMessage, room, itemID);

                    int delayusermove = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new UserMove(itemsUserMove, delayusermove, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_talk_to_avatar:
                    clientMessage.PopInt();
                    bool IsCrier = (clientMessage.PopInt() == 1);

                    string BotNameAndMessage = clientMessage.PopString();

                    string[] SplieNAM = BotNameAndMessage.Split('\t');
                    if (SplieNAM.Length != 2)
                        break;
                    string NameBotTalk = SplieNAM[0];
                    string MessageBot = SplieNAM[1];


                    WiredSaver.HandleTriggerSave(new BotTalkToAvatar(NameBotTalk, MessageBot, IsCrier, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_bot_talk:
                    clientMessage.PopInt();
                    bool IsCrier2 = (clientMessage.PopInt() == 1);

                    string BotNameAndMessage2 = clientMessage.PopString();

                    string[] SplieNAM2 = BotNameAndMessage2.Split('\t');
                    if (SplieNAM2.Length != 2)
                        break;
                    string NameBotTalk2 = SplieNAM2[0];
                    string MessageBot2 = SplieNAM2[1];


                    WiredSaver.HandleTriggerSave(new BotTalk(NameBotTalk2, MessageBot2, IsCrier2, room.GetWiredHandler(), roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_leave_team:
                    WiredSaver.HandleTriggerSave(new TeamLeave(roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_act_join_team:
                    clientMessage.PopInt();
                    int TeamId4 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave(new TeamJoin(TeamId4, roomItem.Id), room.GetWiredHandler(), room, roomItem);
                    break;
                #endregion
                #region Condition
                case InteractionType.superwiredcondition:
                    clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new SuperWiredCondition(roomItem, clientMessage.PopString(), Session.GetHabbo().HasFuse("fuse_superwired")), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionfurnishaveusers:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    
                    List<Item> items10 = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniHasUser(roomItem, items10), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionfurnishavenousers:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    
                    List<Item> items12 = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniHasNoUser(roomItem, items12), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionstatepos:
                    clientMessage.PopInt();
                    int EtatActuel2 = clientMessage.PopInt();
                    int DirectionActuel2 = clientMessage.PopInt();
                    int PositionActuel2 = clientMessage.PopInt();
                    clientMessage.PopBoolean();
                    clientMessage.PopBoolean();
                    
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniStatePosMatch(roomItem, WiredSaver.GetItems(clientMessage, room, itemID), EtatActuel2, DirectionActuel2, PositionActuel2), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_stuff_is:
                    clientMessage.PopInt();
                    clientMessage.PopString();

                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniStuffIs(roomItem, WiredSaver.GetItems(clientMessage, room, itemID)), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_not_stuff_is:
                    clientMessage.PopInt();
                    clientMessage.PopString();

                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniNotStuffIs(roomItem, WiredSaver.GetItems(clientMessage, room, itemID)), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionstateposNegative:
                    clientMessage.PopInt();
                    int EtatActuel3 = clientMessage.PopInt();
                    int DirectionActuel3 = clientMessage.PopInt();
                    int PositionActuel3 = clientMessage.PopInt();
                    clientMessage.PopBoolean();
                    clientMessage.PopBoolean();
                    
                    List<Item> items17 = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave((IWiredCondition)new FurniStatePosMatchNegative(roomItem, items17, EtatActuel3, DirectionActuel3, PositionActuel3), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditiontimelessthan:
                    clientMessage.PopInt();
                    int cycleCount2 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new LessThanTimer(cycleCount2, room, roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditiontimemorethan:
                    clientMessage.PopInt();
                    int cycleCount3 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new MoreThanTimer(cycleCount3, room, roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditiontriggeronfurni:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    
                    List<Item> items9 = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave((IWiredCondition)new TriggerUserIsOnFurni(roomItem, items9), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditiontriggeronfurniNegative:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    
                    List<Item> items14 = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave((IWiredCondition)new TriggerUserIsOnFurniNegative(roomItem, items14), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionhasfurnionfurni:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    
                    List<Item> items13 = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave((IWiredCondition)new HasFurniOnFurni(roomItem, items13), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionhasfurnionfurniNegative:
                    clientMessage.PopInt();
                    clientMessage.PopString();
                    
                    List<Item> items15 = WiredSaver.GetItems(clientMessage, room, itemID);
                    WiredSaver.HandleTriggerSave((IWiredCondition)new HasFurniOnFurniNegative(roomItem, items15), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionactoringroup:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new HasUserInGroup(roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_not_user_count:
                    clientMessage.PopInt();
                    int UserCountMin = clientMessage.PopInt();
                    int UserCountMax = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new RoomUserNotCount(roomItem, UserCountMin, UserCountMax), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_user_count_in:
                    clientMessage.PopInt();
                    int UserCountMin2 = clientMessage.PopInt();
                    int UserCountMax2 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new RoomUserCount(roomItem, UserCountMin2, UserCountMax2), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.conditionnotingroup:
                    WiredSaver.HandleTriggerSave((IWiredCondition)new HasUserNotInGroup(roomItem), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_actor_in_team:
                    clientMessage.PopInt();
                    int TeamId5 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new ActorInTeam(roomItem.Id, TeamId5), room.GetWiredHandler(), room, roomItem);
                    break;
                case InteractionType.wf_cnd_not_in_team:
                    clientMessage.PopInt();
                    int TeamId2 = clientMessage.PopInt();
                    WiredSaver.HandleTriggerSave((IWiredCondition)new ActorNotInTeam(roomItem.Id, TeamId2), room.GetWiredHandler(), room, roomItem);
                    break;
                #endregion
            }
            Session.SendPacket(new ServerPacket(ServerPacketHeader.SaveWired));
        }

        private static List<Item> GetItems(ClientPacket message, Room room, int itemID)
        {
            List<Item> list = new List<Item>();
            int itemCount = message.PopInt();
            for (int index = 0; index < itemCount; ++index)
            {
                Item roomItem = room.GetRoomItemHandler().GetItem(message.PopInt());
                if (roomItem != null && index < 10 && roomItem.GetBaseItem().Type == 's') // && !WiredUtillity.TypeIsWired(roomItem.GetBaseItem().InteractionType)
                    list.Add(roomItem);
            }

            return list;
        }

        private static void HandleTriggerSave(IWired handler, WiredHandler manager, Room room, Item roomItem)
        {
            if (roomItem == null)
                return;
            roomItem.WiredHandler = handler;
            manager.RemoveFurniture(roomItem);
            manager.AddFurniture(roomItem);
            using (IQueryAdapter queryreactor = ButterflyEnvironment.GetDatabaseManager().GetQueryReactor())
                handler.SaveToDatabase(queryreactor);
        }
    }
}
