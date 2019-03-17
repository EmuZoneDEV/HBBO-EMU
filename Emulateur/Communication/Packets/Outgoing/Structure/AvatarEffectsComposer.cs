using System.Collections.Generic;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class AvatarEffectsComposer : ServerPacket
    {
        public AvatarEffectsComposer(List<int> Enable)
            : base(ServerPacketHeader.AvatarEffectsMessageComposer)
        {
            base.WriteInteger(Enable.Count);

            foreach (int EffectId in Enable)
            {
                base.WriteInteger(EffectId);//Effect Id
                base.WriteInteger(1);//Type, 0 = Hand, 1 = Full
                base.WriteInteger(0);
                base.WriteInteger(1);
                base.WriteInteger(-1);
                base.WriteBoolean(true);//Permanent
            }
        }
    }
}
