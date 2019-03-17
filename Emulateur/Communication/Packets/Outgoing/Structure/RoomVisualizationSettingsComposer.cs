namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class RoomVisualizationSettingsComposer : ServerPacket
    {
        public RoomVisualizationSettingsComposer(int Walls, int Floor, bool HideWalls)
            : base(ServerPacketHeader.RoomVisualizationSettingsMessageComposer)
        {
            base.WriteBoolean(HideWalls);
            base.WriteInteger(Walls);
            base.WriteInteger(Floor);
        }
    }
}
