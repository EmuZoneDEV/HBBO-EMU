using Butterfly.HabboHotel.Users;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UserPerksComposer : ServerPacket
    {
        public UserPerksComposer(Habbo Habbo)
            : base(ServerPacketHeader.UserPerksMessageComposer)
        {
            base.WriteInteger(16); // Count
            base.WriteString("USE_GUIDE_TOOL");
            base.WriteString("");
            base.WriteBoolean(Habbo.HasFuse("fuse_helptool"));

            base.WriteString("GIVE_GUIDE_TOURS");
            base.WriteString("requirement.unfulfilled.helper_le");
            base.WriteBoolean(false);

            base.WriteString("JUDGE_CHAT_REVIEWS");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("VOTE_IN_COMPETITIONS");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("CALL_ON_HELPERS");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("CITIZEN");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("TRADE");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("HEIGHTMAP_EDITOR_BETA");
            base.WriteString(""); // ??
            base.WriteBoolean(false);

            base.WriteString("EXPERIMENTAL_CHAT_BETA");
            base.WriteString("requirement.unfulfilled.helper_level_2");
            base.WriteBoolean(true);

            base.WriteString("EXPERIMENTAL_TOOLBAR");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("BUILDER_AT_WORK");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("NAVIGATOR_PHASE_ONE_2014");
            base.WriteString(""); // ??
            base.WriteBoolean(false);

            base.WriteString("CAMERA");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("NAVIGATOR_PHASE_TWO_2014");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("MOUSE_ZOOM");
            base.WriteString(""); // ??
            base.WriteBoolean(true);

            base.WriteString("NAVIGATOR_ROOM_THUMBNAIL_CAMERA");
            base.WriteString(""); // ??
            base.WriteBoolean(false);
        }
    }
}
