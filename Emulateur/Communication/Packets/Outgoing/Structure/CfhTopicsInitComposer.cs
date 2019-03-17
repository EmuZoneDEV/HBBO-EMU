using Butterfly.HabboHotel.Support;
using System.Collections.Generic;
using System.Linq;

namespace Butterfly.Communication.Packets.Outgoing
{
    class CfhTopicsInitComposer : ServerPacket
    {
        public CfhTopicsInitComposer(Dictionary<string, List<ModerationPresetActions>> UserActionPresets)
            : base(ServerPacketHeader.CfhTopicsInitMessageComposer)
        {

            base.WriteInteger(UserActionPresets.Count);
            foreach (KeyValuePair<string, List<ModerationPresetActions>> Cat in UserActionPresets.ToList())
            {
                base.WriteString(Cat.Key);
                base.WriteInteger(Cat.Value.Count);
                foreach (ModerationPresetActions Preset in Cat.Value.ToList())
                {
                    base.WriteString(Preset.Caption);
                    base.WriteInteger(Preset.Id);
                    base.WriteString(Preset.Type);
                }
            }
        }
    }
}
