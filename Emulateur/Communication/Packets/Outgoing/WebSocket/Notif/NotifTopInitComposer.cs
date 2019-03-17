using System.Collections.Generic;

namespace Butterfly.Communication.Packets.Outgoing.WebSocket
{
    class NotifTopInitComposer : ServerPacket
    {
        public NotifTopInitComposer(List<string> Messages)
         : base(19)
        {
            base.WriteInteger(Messages.Count);

            foreach(string Message in Messages)
                base.WriteString(Message);
        }
    }
}
