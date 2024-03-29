﻿// Type: Butterfly.HabboHotel.Rooms.Wired.WiredHandlers.Triggers.GameStarts




using Butterfly.HabboHotel.Items;
using Butterfly.HabboHotel.Rooms.Games;
using Butterfly.HabboHotel.Rooms.Wired.WiredHandlers.Interfaces;
using Butterfly.Database.Interfaces;
using System;

using Butterfly.Communication.Packets.Outgoing;
using Butterfly.HabboHotel.GameClients;

namespace Butterfly.HabboHotel.Rooms.Wired.WiredHandlers.Triggers
{
    public class GameStarts : IWired
  {
    private Item item;
    private WiredHandler handler;
    private readonly RoomEventDelegate gameStartsDeletgate;

    public GameStarts(Item item, WiredHandler handler, GameManager gameManager)
    {
      this.item = item;
      this.handler = handler;
      this.gameStartsDeletgate = new RoomEventDelegate(this.gameManager_OnGameStart);
      gameManager.OnGameStart += this.gameStartsDeletgate;
    }

    private void gameManager_OnGameStart(object sender, EventArgs e)
    {
      this.handler.ExecutePile(this.item.Coordinate,  (RoomUser) null, null);
    }

    public void Dispose()
    {
      this.handler.GetRoom().GetGameManager().OnGameStart -= this.gameStartsDeletgate;
      this.item = (Item) null;
      this.handler = (WiredHandler) null;
    }

    public void SaveToDatabase(IQueryAdapter dbClient)
    {
    }

    public void LoadFromDatabase(IQueryAdapter dbClient, Room insideRoom)
    {
    }

    public void DeleteFromDatabase(IQueryAdapter dbClient)
    {
    }
    public void OnTrigger(GameClient Session, int SpriteId)
    {
        ServerPacket Message4 = new ServerPacket(ServerPacketHeader.WiredTriggerConfigMessageComposer);
        Message4.WriteBoolean(false);
        Message4.WriteInteger(0);
        Message4.WriteInteger(0);
        Message4.WriteInteger(SpriteId);
        Message4.WriteInteger(this.item.Id);
        Message4.WriteString("");
        Message4.WriteInteger(0);
        Message4.WriteInteger(0);
        Message4.WriteInteger(8);
        Message4.WriteInteger(0);
        Message4.WriteInteger(0);
        Message4.WriteInteger(0);
        Session.SendPacket(Message4);
    }
  }
}
