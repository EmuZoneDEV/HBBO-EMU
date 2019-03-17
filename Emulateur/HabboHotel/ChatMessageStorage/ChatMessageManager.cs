using Butterfly.Communication.Packets.Outgoing;
using System.Collections.Generic;
using System;

namespace Butterfly.HabboHotel.ChatMessageStorage
{
    public class ChatMessageManager
    {
        private readonly List<ChatMessage> listOfMessages;

        public int messageCount
        {
            get
            {
                return this.listOfMessages.Count;
            }
        }

        public ChatMessageManager()
        {
            this.listOfMessages = new List<ChatMessage>();
        }
        
        public void AddMessage(int UserId, string Username, int RoomId, string MessageText)
        {
            ChatMessage message = new ChatMessage(UserId, Username, RoomId, MessageText, DateTime.Now);

            lock (this.listOfMessages)
                this.listOfMessages.Add(message);

            int CountMessage = this.listOfMessages.Count;
            if (CountMessage >= 100)
                this.listOfMessages.RemoveRange(0, 1);
        }

        public List<ChatMessage> GetSortedMessages(int roomid)
        {
            List<ChatMessage> list = new List<ChatMessage>();

            foreach (ChatMessage chatMessage in this.listOfMessages)
            {
                if (roomid == chatMessage.roomID || roomid == 0)
                {
                    list.Add(chatMessage);
                }
            }
            list.Reverse();
            return list;
        }

        public void Serialize(ref ServerPacket message)
        {
            List<ChatMessage> ListReverse = new List<ChatMessage>();
            ListReverse.AddRange(this.listOfMessages);
            ListReverse.Reverse();
            foreach (ChatMessage chatMessage in ListReverse)
            {
                if (chatMessage != null)
                {
                    chatMessage.Serialize(ref message);
                }
                else
                {
                    message.WriteString("0"); //this.timeSpoken.Minute
                    message.WriteInteger(0); //this.timeSpoken.Minute
                    message.WriteString("Erreur");
                    message.WriteString("Erreur");
                    message.WriteBoolean(false); // Text is bold
                }
            }
        }
    }
}
