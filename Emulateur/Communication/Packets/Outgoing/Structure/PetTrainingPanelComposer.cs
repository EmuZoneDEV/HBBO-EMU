using Butterfly.HabboHotel.Pets;
using System.Collections.Generic;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class PetTrainingPanelComposer : ServerPacket
    {
        public PetTrainingPanelComposer(Pet petData)
            : base(ServerPacketHeader.PetTrainingPanelMessageComposer)
        {
            base.WriteInteger(petData.PetId);

            List<short> AvailableCommands = new List<short>();

            base.WriteInteger(petData.PetCommands.Count);
            foreach (short Sh in petData.PetCommands.Keys)
            {
                base.WriteInteger(Sh);
                if (petData.PetCommands[Sh] == true)
                {
                    AvailableCommands.Add(Sh);
                }
            }

            base.WriteInteger(AvailableCommands.Count);
            foreach (short Sh in AvailableCommands)
            {
                base.WriteInteger(Sh);
            }
        }
    }
}
