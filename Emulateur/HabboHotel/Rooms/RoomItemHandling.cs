using Butterfly.Core;
using Butterfly.HabboHotel.GameClients;
using Butterfly.HabboHotel.Items;
using Butterfly.HabboHotel.Pathfinding;
using Butterfly.HabboHotel.Rooms.Wired;
using Butterfly.Communication.Packets.Outgoing;
using Butterfly.Utilities;
using Butterfly.Database.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections.Concurrent;
using Butterfly.Communication.Packets.Outgoing.Structure;
using Butterfly.HabboHotel.Rooms.Map.Movement;

namespace Butterfly.HabboHotel.Rooms
{
    public class RoomItemHandling
    {
        private Room room;

        private ConcurrentDictionary<int, Item> _floorItems;
        private ConcurrentDictionary<int, Item> _wallItems;
        private readonly ConcurrentDictionary<int, Item> _rollers;

        private ConcurrentDictionary<int, ItemTemp> _itemsTemp;

        private readonly ConcurrentDictionary<int, Item> mUpdateItems;

        private readonly List<int> rollerItemsMoved;
        private readonly List<int> rollerUsersMoved;
        private readonly List<ServerPacket> rollerMessages;
        
        private int mRollerSpeed;
        private int mRoolerCycle;
        private readonly ConcurrentQueue<Item> _roomItemUpdateQueue;
        private int _itemTempoId;

        public Room GetRoom
        {
            get
            {
                return this.room;
            }
        }

        public RoomItemHandling(Room room)
        {
            this.room = room;
            this.mUpdateItems = new ConcurrentDictionary<int, Item>();
            this._rollers = new ConcurrentDictionary<int, Item>();
            this._wallItems = new ConcurrentDictionary<int, Item>();
            this._floorItems = new ConcurrentDictionary<int, Item>();
            this._itemsTemp = new ConcurrentDictionary<int, ItemTemp>();
            this._itemTempoId = 0;
            this._roomItemUpdateQueue = new ConcurrentQueue<Item>();
            this.mRoolerCycle = 0;
            this.mRollerSpeed = 4;
            this.rollerItemsMoved = new List<int>();
            this.rollerUsersMoved = new List<int>();
            this.rollerMessages = new List<ServerPacket>();
        }

        public void QueueRoomItemUpdate(Item item)
        {
            this._roomItemUpdateQueue.Enqueue(item);
        }

        public List<Item> RemoveAllFurniture(GameClient Session)
        {
            List<ServerPacket> ListMessage = new List<ServerPacket>();
            List<Item> Items = new List<Item>();
            foreach (Item roomItem in this._floorItems.Values.ToList())
            {
                roomItem.Interactor.OnRemove(Session, roomItem);

                roomItem.Destroy();
                ListMessage.Add(new ObjectRemoveMessageComposer(roomItem.Id, Session.GetHabbo().Id));
                Items.Add(roomItem);
            }
            foreach (Item roomItem in this._wallItems.Values.ToList())
            {
                roomItem.Interactor.OnRemove(Session, roomItem);
                roomItem.Destroy();

                ServerPacket Message = new ServerPacket(ServerPacketHeader.ItemRemoveMessageComposer);
                Message.WriteString(roomItem.Id + string.Empty);
                Message.WriteInteger(this.room.RoomData.OwnerId);
                ListMessage.Add(Message);
                Items.Add(roomItem);
            }
            this.room.SendMessage(ListMessage);

            this._wallItems.Clear();
            this._floorItems.Clear();
            this._itemsTemp.Clear();
            this.mUpdateItems.Clear();
            this._rollers.Clear();
            using (IQueryAdapter queryreactor = ButterflyEnvironment.GetDatabaseManager().GetQueryReactor())
                queryreactor.RunQuery("UPDATE items SET room_id = '0', user_id = '" + this.room.RoomData.OwnerId + "' WHERE room_id = " + this.room.Id);

            this.room.GetGameMap().GenerateMaps();
            this.room.GetRoomUserManager().UpdateUserStatusses();
            if (this.room.GotWired())
                this.room.GetWiredHandler().OnPickall();
            return Items;
        }

        public void SetSpeed(int p)
        {
            this.mRollerSpeed = p;
        }
        

        public void LoadFurniture()
        {
            this._floorItems.Clear();
            this._wallItems.Clear();
            using (IQueryAdapter queryreactor = ButterflyEnvironment.GetDatabaseManager().GetQueryReactor())
            {
                queryreactor.SetQuery("SELECT items.id, items.user_id, items.room_id, items.base_item, items.extra_data, items.x, items.y, items.z, items.rot, items.wall_pos, items_limited.limited_number, items_limited.limited_stack FROM items LEFT JOIN items_limited ON (items_limited.item_id = items.id) WHERE items.room_id = @roomid");
                queryreactor.AddParameter("roomid", this.room.Id);

                int itemID;
                int UserId;
                int baseID;
                string ExtraData;
                int x;
                int y;
                double z;
                sbyte n;
                string wallposs;
                int Limited;
                int LimitedTo;
                string wallCoord;

                foreach (DataRow dataRow in queryreactor.GetTable().Rows)
                {

                    itemID = Convert.ToInt32(dataRow[0]);
                    UserId = Convert.ToInt32(dataRow[1]);
                    baseID = Convert.ToInt32(dataRow[3]);
                    ExtraData = !DBNull.Value.Equals(dataRow[4]) ? (string)dataRow[4] : string.Empty;
                    x = Convert.ToInt32(dataRow[5]);
                    y = Convert.ToInt32(dataRow[6]);
                    z = Convert.ToDouble(dataRow[7]);
                    n = Convert.ToSByte(dataRow[8]);
                    wallposs = !DBNull.Value.Equals(dataRow[9]) ? (string)(dataRow[9]) : string.Empty;
                    Limited = !DBNull.Value.Equals(dataRow[10]) ? Convert.ToInt32(dataRow[10]) : 0;
                    LimitedTo = !DBNull.Value.Equals(dataRow[11]) ? Convert.ToInt32(dataRow[11]) : 0;

                    ItemData Data = null;
                    ButterflyEnvironment.GetGame().GetItemManager().GetItem(baseID, out Data);

                    if (Data == null)
                        continue;

                    if (Data.Type.ToString() == "i")
                    {
                        if (string.IsNullOrEmpty(wallposs))
                            wallCoord = "w=0,0 l=0,0 l";
                        else
                            wallCoord = wallposs;//WallPositionCheck(":" + wallposs.Split(':')[1]);

                        Item roomItem = new Item(itemID, this.room.Id, baseID, ExtraData, Limited, LimitedTo, 0, 0, 0.0, 0, wallCoord, this.room);
                        if (!this._wallItems.ContainsKey(itemID))
                            this._wallItems.TryAdd(itemID, roomItem);

                        if (roomItem.GetBaseItem().InteractionType == InteractionType.MOODLIGHT)
                        {
                            if (this.room.MoodlightData == null)
                                this.room.MoodlightData = new MoodlightData(roomItem.Id);
                        }
                    }
                    else //Is flooritem
                    {
                        Item roomItem = new Item(itemID, this.room.Id, baseID, ExtraData, Limited, LimitedTo, x, y, (double)z, n, "",this.room);

                        if (!this._floorItems.ContainsKey(itemID))
                            this._floorItems.TryAdd(itemID, roomItem);
                    }
                }

                foreach (Item Item in _floorItems.Values)
                {
                    if (WiredUtillity.TypeIsWired(Item.GetBaseItem().InteractionType))
                    {
                        WiredLoader.LoadWiredItem(Item, this.room, queryreactor);
                        //this.room.GetWiredHandler().AddWire(roomItem, roomItem.Coordinate, roomItem.Rot, roomItem.GetBaseItem().InteractionType);
                    }
                }
            }
        }

        public ICollection<Item> GetFloor
        {
            get
            {
                return this._floorItems.Values;
            }
        }
        

        public ItemTemp GetFirstTempDrop(int x, int y)
        {
            foreach(ItemTemp Item in _itemsTemp.Values)
            {
                if (Item.InteractionType != InteractionTypeTemp.RPITEM && Item.InteractionType != InteractionTypeTemp.MONEY)
                    continue;

                if (Item.X != x || Item.Y != y)
                    continue;


                return Item;
            }

            return null;
        }

        public ItemTemp GetTempItem(int pId)
        {
            if(_itemsTemp != null && _itemsTemp.ContainsKey(pId))
            {
                ItemTemp Item = null;
                if (_itemsTemp.TryGetValue(pId, out Item))
                    return Item;
            }

            return null;
        }

        public Item GetItem(int pId)
        {
            if (_floorItems != null && _floorItems.ContainsKey(pId))
            {
                Item Item = null;
                if (_floorItems.TryGetValue(pId, out Item))
                    return Item;
            }
            else if (_wallItems != null && _wallItems.ContainsKey(pId))
            {
                Item Item = null;
                if (_wallItems.TryGetValue(pId, out Item))
                    return Item;
            }

            return null;
        }

        public ICollection<ItemTemp> GetTempItems
        {
            get
            {
                return this._itemsTemp.Values;
            }
        }

        public ICollection<Item> GetWall
        {
            get
            {
                return this._wallItems.Values;
            }
        }

        public IEnumerable<Item> GetWallAndFloor
        {
            get
            {
                return this._floorItems.Values.Concat(this._wallItems.Values);
            }
        }

        public void RemoveFurniture(GameClient Session, int pId)
        {
            Item roomItem = this.GetItem(pId);
            if (roomItem == null)
                return;
            
            roomItem.Interactor.OnRemove(Session, roomItem);

            this.RemoveRoomItem(roomItem);

            if (roomItem.WiredHandler != null)
            {
                using (IQueryAdapter queryreactor = ButterflyEnvironment.GetDatabaseManager().GetQueryReactor())
                {
                    roomItem.WiredHandler.DeleteFromDatabase(queryreactor);
                }
                roomItem.WiredHandler.Dispose();
                this.room.GetWiredHandler().RemoveFurniture(roomItem);
                roomItem.WiredHandler = null;
            }
            roomItem.Destroy();
        }

        public void RemoveTempItem(int pId)
        {
            ItemTemp Item = this.GetTempItem(pId);
            if (Item == null)
                return;

            this.room.SendPacket(new ObjectRemoveMessageComposer(Item.Id, 0));
            this._itemsTemp.TryRemove(pId, out Item);
        }

        private void RemoveRoomItem(Item Item)
        {
            if (Item.IsWallItem)
            {
                ServerPacket Message = new ServerPacket(ServerPacketHeader.ItemRemoveMessageComposer);
                Message.WriteString(Item.Id.ToString());
                Message.WriteInteger(this.room.RoomData.OwnerId);
                this.room.SendPacket(Message);
            }
            else if (Item.IsFloorItem)
            {
                this.room.SendPacket(new ObjectRemoveMessageComposer(Item.Id, this.room.RoomData.OwnerId));
            }


            if (Item.IsWallItem)
            {
                this._wallItems.TryRemove(Item.Id, out Item);
            }
            else
            {
                this._floorItems.TryRemove(Item.Id, out Item);
                this.room.GetGameMap().RemoveFromMap(Item);
            }

            if (this.mUpdateItems.ContainsKey(Item.Id))
                this.mUpdateItems.TryRemove(Item.Id, out Item);

            if (this._rollers.ContainsKey(Item.Id))
                this._rollers.TryRemove(Item.Id, out Item);

            foreach (ThreeDCoord threeDcoord in Item.GetAffectedTiles.Values)
            {
                List<RoomUser> userForSquare = this.room.GetGameMap().GetRoomUsers(new Point(threeDcoord.X, threeDcoord.Y));
                if (userForSquare == null)
                    continue;
                foreach (RoomUser User in userForSquare)
                {
                    if (!User.IsWalking)
                        this.room.GetRoomUserManager().UpdateUserStatus(User, false);
                }
            }
        }

        private List<ServerPacket> CycleRollers()
        {
            if (this.mRoolerCycle >= this.mRollerSpeed || this.mRollerSpeed == 0)
            {
                this.rollerItemsMoved.Clear();
                this.rollerUsersMoved.Clear();
                this.rollerMessages.Clear();

                foreach (Item Roller in this._rollers.Values.ToList())
                {
                    Point NextSquare = Roller.SquareInFront;
                    List<Item> ItemsOnRoller = this.room.GetGameMap().GetRoomItemForSquare(Roller.GetX, Roller.GetY, Roller.GetZ);
                    RoomUser userForSquare = this.room.GetRoomUserManager().GetUserForSquare(Roller.GetX, Roller.GetY);

                    if (ItemsOnRoller.Count > 0 || userForSquare != null)
                    {

                        if (ItemsOnRoller.Count > 10)
                            ItemsOnRoller = ItemsOnRoller.Take(10).ToList();

                        List<Item> ItemsOnNext = this.room.GetGameMap().GetCoordinatedItems(NextSquare);
                        bool NextRoller = false;
                        double NextZ = 0.0;
                        bool NextRollerClear = true;
                        foreach (Item roomItem2 in ItemsOnNext)
                        {
                            if (roomItem2.IsRoller)
                            {
                                NextRoller = true;
                                if (roomItem2.TotalHeight > NextZ)
                                    NextZ = roomItem2.TotalHeight;
                            }
                        }
                        if (NextRoller)
                        {
                            foreach (Item roomItem2 in ItemsOnNext)
                            {
                                if (roomItem2.TotalHeight > NextZ)
                                    NextRollerClear = false;
                            }
                        }
                        else
                            NextZ += this.room.GetGameMap().GetHeightForSquareFromData(NextSquare);

                        foreach (Item pItem in ItemsOnRoller)
                        {
                            double RollerHeight = pItem.GetZ - Roller.TotalHeight;
                            if (!this.rollerItemsMoved.Contains(pItem.Id) && this.room.GetGameMap().CanStackItem(NextSquare.X, NextSquare.Y) && (NextRollerClear && Roller.GetZ < pItem.GetZ))
                            {
                                this.rollerMessages.Add(this.UpdateItemOnRoller(pItem, NextSquare, NextZ + RollerHeight));
                                this.rollerItemsMoved.Add(pItem.Id);
                            }
                        }

                        if (userForSquare != null && (!userForSquare.SetStep && (userForSquare.AllowMoveRoller || this.mRollerSpeed == 0) && (!userForSquare.IsWalking || userForSquare.Freeze)) && NextRollerClear && (this.room.GetGameMap().CanWalk(NextSquare.X, NextSquare.Y) && this.room.GetGameMap().SquareTakingOpen(NextSquare.X, NextSquare.Y) && !this.rollerUsersMoved.Contains(userForSquare.HabboId)))
                        {
                            this.rollerMessages.Add(this.UpdateUserOnRoller(userForSquare, NextSquare, Roller.Id, NextZ));
                            this.rollerUsersMoved.Add(userForSquare.HabboId);
                        }
                    }
                }
                this.mRoolerCycle = 0;
                return this.rollerMessages;
            }
            else
                ++this.mRoolerCycle;
            return new List<ServerPacket>();
        }

        public void PositionReset(Item pItem, int x, int y, double z)
        {
            ServerPacket serverMessage = new ServerPacket(ServerPacketHeader.SlideObjectBundleMessageComposer);
            serverMessage.WriteInteger(pItem.GetX);
            serverMessage.WriteInteger(pItem.GetY);
            serverMessage.WriteInteger(x);
            serverMessage.WriteInteger(y);

            serverMessage.WriteInteger(1); //Count user or item on roller
            serverMessage.WriteInteger(pItem.Id);
            serverMessage.WriteString(TextHandling.GetString(pItem.GetZ));
            serverMessage.WriteString(TextHandling.GetString(z));

            serverMessage.WriteInteger(0);
            this.room.SendPacket(serverMessage);

            this.SetFloorItem(pItem, x, y, z);
        }

        public void RotReset(Item pItem, int newRot)
        {
            pItem.Rotation = newRot;
            
            room.SendPacket(new ObjectUpdateComposer(pItem, room.RoomData.OwnerId));
        }

        private ServerPacket UpdateItemOnRoller(Item pItem, Point NextCoord, double NextZ)
        {
            ServerPacket serverMessage = new ServerPacket(ServerPacketHeader.SlideObjectBundleMessageComposer);
            serverMessage.WriteInteger(pItem.GetX);
            serverMessage.WriteInteger(pItem.GetY);
            serverMessage.WriteInteger(NextCoord.X);
            serverMessage.WriteInteger(NextCoord.Y);
            serverMessage.WriteInteger(1);
            serverMessage.WriteInteger(pItem.Id);
            serverMessage.WriteString(TextHandling.GetString(pItem.GetZ));
            serverMessage.WriteString(TextHandling.GetString(NextZ));
            serverMessage.WriteInteger(0);
            this.SetFloorItem(pItem, NextCoord.X, NextCoord.Y, NextZ);
            return serverMessage;
        }

        public ServerPacket UpdateUserOnRoller(RoomUser pUser, Point pNextCoord, int pRollerID, double NextZ)
        {
            ServerPacket serverMessage = new ServerPacket(ServerPacketHeader.SlideObjectBundleMessageComposer);
            serverMessage.WriteInteger(pUser.X);
            serverMessage.WriteInteger(pUser.Y);
            serverMessage.WriteInteger(pNextCoord.X);
            serverMessage.WriteInteger(pNextCoord.Y);
            serverMessage.WriteInteger(0); //Count items or Users on roller
            serverMessage.WriteInteger(pRollerID);
            serverMessage.WriteInteger(2); //Type
            serverMessage.WriteInteger(pUser.VirtualId);
            serverMessage.WriteString(TextHandling.GetString(pUser.Z));
            serverMessage.WriteString(TextHandling.GetString(NextZ));

            pUser.SetPosRoller(pNextCoord.X, pNextCoord.Y, NextZ);

            return serverMessage;
        }

        public ServerPacket TeleportUser(RoomUser pUser, Point pNextCoord, int pRollerID, double NextZ)
        {
            ServerPacket serverMessage = new ServerPacket(ServerPacketHeader.SlideObjectBundleMessageComposer);
            serverMessage.WriteInteger(pUser.X);
            serverMessage.WriteInteger(pUser.Y);
            serverMessage.WriteInteger(pNextCoord.X);
            serverMessage.WriteInteger(pNextCoord.Y);
            serverMessage.WriteInteger(0);
            serverMessage.WriteInteger(pRollerID);
            serverMessage.WriteInteger(2);
            serverMessage.WriteInteger(pUser.VirtualId);
            serverMessage.WriteString(TextHandling.GetString(pUser.Z));
            serverMessage.WriteString(TextHandling.GetString(NextZ));

            pUser.SetPos(pNextCoord.X, pNextCoord.Y, NextZ);

            return serverMessage;
        }


        public void SaveFurniture(IQueryAdapter dbClient)
        {
            try
            {
                if (this.mUpdateItems.Count <= 0 && this.room.GetRoomUserManager().BotCount <= 0)
                    return;
                if (this.mUpdateItems.Count > 0)
                {
                    QueryChunk standardQueries = new QueryChunk();

                    foreach (Item roomItem in (IEnumerable)this.mUpdateItems.Values)
                    {
                        if (!string.IsNullOrEmpty(roomItem.ExtraData))
                        {
                            standardQueries.AddQuery(string.Concat(new object[4]
                          {
                             "UPDATE items SET extra_data = @data",
                             roomItem.Id,
                             " WHERE id = ",
                             roomItem.Id
                          }));
                            standardQueries.AddParameter("data" + roomItem.Id, roomItem.ExtraData);
                        }
                        if (roomItem.IsWallItem)
                        {
                            standardQueries.AddQuery("UPDATE items SET wall_pos = @wallpost" + roomItem.Id + " WHERE id = " + roomItem.Id);
                            standardQueries.AddParameter("wallpost" + roomItem.Id, roomItem.wallCoord);
                        }
                        else
                        {
                            standardQueries.AddQuery("UPDATE items SET x=" + roomItem.GetX + ", y=" + roomItem.GetY + ", z=" + roomItem.GetZ + ", rot=" + roomItem.Rotation + " WHERE id=" + roomItem.Id + "");
                        }
                    }

                    standardQueries.Execute(dbClient);
                    standardQueries.Dispose();

                    this.mUpdateItems.Clear();
                }
                this.room.GetRoomUserManager().AppendPetsUpdateString(dbClient);
                this.room.GetRoomUserManager().SavePositionBots(dbClient);
            }
            catch (Exception ex)
            {
                Logging.LogCriticalException(string.Concat(new object[4]
          {
             "Error during saving furniture for room ",
             this.room.Id,
             ". Stack: ",
             ( ex).ToString()
          }));
            }
        }

        public ItemTemp AddTempItem(int vId, int spriteId, int x, int y, double z, string extraData, int value = 0, InteractionTypeTemp pInteraction = InteractionTypeTemp.NONE, MovementDirection movement = MovementDirection.none, int pDistance = 0, int pTeamId = 0)
        {
            int id = this._itemTempoId--;
            ItemTemp Item = new ItemTemp(id, vId, spriteId, x, y, z, extraData, movement, value, pInteraction, pDistance, pTeamId);

            if (!this._itemsTemp.ContainsKey(Item.Id))
                this._itemsTemp.TryAdd(Item.Id, Item);

            this.room.SendPacket(new ObjectAddComposer(Item));

            return Item;
        }

        public bool SetFloorItem(GameClient Session, Item Item, int newX, int newY, int newRot, bool newItem, bool OnRoller, bool sendMessage)
        {
            bool NeedsReAdd = false;
            if (!newItem)
                NeedsReAdd = this.room.GetGameMap().RemoveFromMap(Item);

            Dictionary<int, ThreeDCoord> affectedTiles = Gamemap.GetAffectedTiles(Item.GetBaseItem().Length, Item.GetBaseItem().Width, newX, newY, newRot);
            foreach (ThreeDCoord threeDcoord in affectedTiles.Values)
            {
                if (!this.room.GetGameMap().ValidTile(threeDcoord.X, threeDcoord.Y) || this.room.GetGameMap().SquareHasUsers(threeDcoord.X, threeDcoord.Y) || this.room.GetGameMap().Model.SqState[threeDcoord.X, threeDcoord.Y] != SquareState.OPEN) // && !Item.GetBaseItem().IsSeat
                {
                    if (NeedsReAdd)
                    {
                        this.UpdateItem(Item);
                        this.room.GetGameMap().AddToMap(Item);
                    }
                    return false;
                }
            }

            double pZ = (double)this.room.GetGameMap().Model.SqFloorHeight[newX, newY];
            
            List<Item> ItemsAffected = new List<Item>();
            List<Item> ItemsComplete = new List<Item>();

            foreach (ThreeDCoord threeDcoord in affectedTiles.Values)
            {
                List<Item> Temp = this.room.GetGameMap().GetCoordinatedItems(new Point(threeDcoord.X, threeDcoord.Y));
                if (Temp != null)
                    ItemsAffected.AddRange(Temp);
            }
            //ItemsComplete.AddRange(ItemsOnTile);
            ItemsComplete.AddRange(ItemsAffected);


            bool ConstruitMode = false;
            bool ConstruitZMode = false;
            double ConstruitHeigth = 1.0;
            bool PileMagic = false;

            if (Item.GetBaseItem().InteractionType == InteractionType.pilemagic)
                PileMagic = true;

            if (Session != null && Session.GetHabbo() != null && Session.GetHabbo().CurrentRoom != null)
            {
                RoomUser User_room = Session.GetHabbo().CurrentRoom.GetRoomUserManager().GetRoomUserByHabboId(Session.GetHabbo().Id);
                if (User_room != null)
                {
                    ConstruitMode = User_room.ConstruitMode;
                    ConstruitZMode = User_room.ConstruitZMode;
                    ConstruitHeigth = User_room.ConstruitHeigth;
                }
            }

            if (Item.Rotation != newRot && Item.GetX == newX && Item.GetY == newY && !ConstruitZMode)
                pZ = Item.GetZ;

            if (ConstruitZMode)
                pZ = pZ + ConstruitHeigth;
            else
            {
                foreach (Item roomItem in ItemsComplete)
                {
                    if (roomItem.GetBaseItem().InteractionType == InteractionType.pilemagic)
                    {
                        pZ = roomItem.GetZ;
                        PileMagic = true;
                        break;
                    }
                    if (roomItem.Id != Item.Id && roomItem.TotalHeight > pZ)
                        if (ConstruitMode)
                            pZ = roomItem.GetZ + ConstruitHeigth;
                        else
                            pZ = roomItem.TotalHeight;
                }
            }

            if (!OnRoller)
            {
                foreach (Item roomItem in ItemsComplete)
                {
                    if (roomItem != null && roomItem.Id != Item.Id && (roomItem.GetBaseItem() != null && (!roomItem.GetBaseItem().Stackable && !ConstruitMode && !PileMagic && !ConstruitZMode)))
                    {
                        if (NeedsReAdd)
                        {
                            this.UpdateItem(Item);
                            this.room.GetGameMap().AddToMap(Item);
                        }
                        return false;
                    }
                }
            }

            foreach (ThreeDCoord threeDcoord in Item.GetAffectedTiles.Values)
            {
                List<RoomUser> userForSquare = this.room.GetGameMap().GetRoomUsers(new Point(threeDcoord.X, threeDcoord.Y));
                if (userForSquare == null)
                    continue;
                foreach (RoomUser User in userForSquare)
                {
                    if (!User.IsWalking)
                        this.room.GetRoomUserManager().UpdateUserStatus(User, false);
                }
            }
            
            if (newRot != 1 && newRot != 2 && newRot != 3 && newRot != 4 && newRot != 5 && newRot != 6 && newRot != 7 && newRot != 8)
                newRot = 0;

            Item.Rotation = newRot;
            int getX = Item.GetX;
            int getY = Item.GetY;
            Item.SetState(newX, newY, pZ, affectedTiles);

            if (!OnRoller && Session != null)
                Item.Interactor.OnPlace(Session, Item);

            if (newItem)
            {
                if (this._floorItems.ContainsKey(Item.Id))
                {
                    if (Session != null)
                        Session.SendNotification(ButterflyEnvironment.GetLanguageManager().TryGetValue("room.itemplaced", Session.Langue));
                    return true;
                }
                else
                {
                    if (Item.IsFloorItem && !this._floorItems.ContainsKey(Item.Id))
                        this._floorItems.TryAdd(Item.Id, Item);
                    else if (Item.IsWallItem && !this._wallItems.ContainsKey(Item.Id))
                        this._wallItems.TryAdd(Item.Id, Item);

                    this.UpdateItem(Item);
                    if (sendMessage)
                    {
                        this.room.SendPacket(new ObjectAddComposer(Item, this.room.RoomData.OwnerName, this.room.RoomData.OwnerId));
                    }
                }
            }
            else
            {
                this.UpdateItem(Item);
                if (!OnRoller && sendMessage)
                {
                    room.SendPacket(new ObjectUpdateComposer(Item, room.RoomData.OwnerId));
                }
            }

            this.room.GetGameMap().AddToMap(Item);


            return true;
        }

        public void TryAddRoller(int ItemId, Item Roller)
        {
            this._rollers.TryAdd(ItemId, Roller);
        }

        public ICollection<Item> GetRollers()
        {
            return this._rollers.Values;
        }

        public bool SetFloorItem(Item Item, int newX, int newY, double newZ)
        {
            this.room.GetGameMap().RemoveFromMap(Item);
            Item.SetState(newX, newY, newZ, Gamemap.GetAffectedTiles(Item.GetBaseItem().Length, Item.GetBaseItem().Width, newX, newY, Item.Rotation));
            this.UpdateItem(Item);
            this.room.GetGameMap().AddItemToMap(Item);
            return true;
        }

        public bool SetWallItem(GameClient Session, Item Item)
        {
            if (!Item.IsWallItem || this._wallItems.ContainsKey(Item.Id))
                return false;
            if (this._floorItems.ContainsKey(Item.Id))
            {
                return true;
            }
            else
            {
                Item.Interactor.OnPlace(Session, Item);
                if (Item.GetBaseItem().InteractionType == InteractionType.MOODLIGHT && this.room.MoodlightData == null)
                {
                    this.room.MoodlightData = new MoodlightData(Item.Id);
                    Item.ExtraData = this.room.MoodlightData.GenerateExtraData();
                }
                this._wallItems.TryAdd(Item.Id, Item);
                this.UpdateItem(Item);
                
                this.room.SendPacket(new ItemAddComposer(Item, this.room.RoomData.OwnerName, this.room.RoomData.OwnerId));

                return true;
            }
        }

        public void UpdateItem(Item item)
        {
            if (this.mUpdateItems.ContainsKey(item.Id))
                return;
            this.mUpdateItems.TryAdd(item.Id, item);
        }

        public void OnCycle()
        {
            this.room.SendMessage(this.CycleRollers());

            if (this._roomItemUpdateQueue.Count > 0)
            {
                List<Item> addItems = new List<Item>();

                while (this._roomItemUpdateQueue.Count > 0)
                {
                    Item item = (Item)null;
                    if (this._roomItemUpdateQueue.TryDequeue(out item))
                    {
                        item.ProcessUpdates();

                        if (item.UpdateCounter > 0)
                            addItems.Add(item);
                    }
                }
                foreach (Item item_0 in addItems)
                    this._roomItemUpdateQueue.Enqueue(item_0);
            }
        }

        public void Destroy()
        {
            this._floorItems.Clear();
            this._wallItems.Clear();
            this._itemsTemp.Clear();
            this.mUpdateItems.Clear();
            this.rollerUsersMoved.Clear();
            this.rollerMessages.Clear();
            this.rollerItemsMoved.Clear();
        }
    }
}
