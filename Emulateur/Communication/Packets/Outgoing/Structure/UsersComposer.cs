using Butterfly.HabboHotel.Rooms;
using Butterfly.HabboHotel.Users;
using Butterfly.HabboHotel.Groups;
using System.Collections.Generic;
using Butterfly.HabboHotel.RoomBots;
using System.Linq;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class UsersComposer : ServerPacket
    {
        public UsersComposer(ICollection<RoomUser> Users)
            : base(ServerPacketHeader.UsersMessageComposer)
        {
            base.WriteInteger(Users.Count);
            foreach (RoomUser User in Users.ToList())
            {
                WriteUser(User);
            }
        }

        public UsersComposer(RoomUser User)
            : base(ServerPacketHeader.UsersMessageComposer)
        {
            base.WriteInteger(1);//1 avatar
            WriteUser(User);
        }

        private void WriteUser(RoomUser User)
        {
            if (User.IsBot)
            {
                base.WriteInteger(User.BotAI.BaseId);
                base.WriteString(User.BotData.Name);
                base.WriteString(User.BotData.Motto);
                if (User.BotData.AiType == AIType.Pet || User.BotData.AiType == AIType.RolePlayPet)
                {
                    base.WriteString(User.BotData.Look.ToLower() + ((User.PetData.Saddle > 0) ? " 3 2 " + User.PetData.PetHair + " " + User.PetData.HairDye + " 3 " + User.PetData.PetHair + " " + User.PetData.HairDye + " 4 " + User.PetData.Saddle + " 0" : " 2 2 " + User.PetData.PetHair + " " + User.PetData.HairDye + " 3 " + User.PetData.PetHair + " " + User.PetData.HairDye + ""));

                }
                else
                    base.WriteString(User.BotData.Look);
                base.WriteInteger(User.VirtualId);
                base.WriteInteger(User.X);
                base.WriteInteger(User.Y);
                base.WriteString(TextHandling.GetString(User.Z));
                base.WriteInteger(2);
                base.WriteInteger(User.BotData.AiType == AIType.Pet || User.BotData.AiType == AIType.RolePlayPet ? 2 : 4);
                if (User.BotData.AiType == AIType.Pet || User.BotData.AiType == AIType.RolePlayPet)
                {
                    base.WriteInteger(User.PetData.Type);
                    base.WriteInteger(User.PetData.OwnerId);
                    base.WriteString(User.PetData.OwnerName);
                    base.WriteInteger(1);
                    base.WriteBoolean(User.PetData.Saddle > 0);
                    base.WriteBoolean(User.RidingHorse);
                    base.WriteInteger(0);
                    base.WriteInteger(0);
                    base.WriteString("");
                }
                else
                {
                    base.WriteString(User.BotData.Gender);
                    base.WriteInteger(User.BotData.OwnerId);
                    base.WriteString(User.BotData.OwnerName);
                    base.WriteInteger(5);
                    base.WriteShort(1);
                    base.WriteShort(2);
                    base.WriteShort(3);
                    base.WriteShort(4);
                    base.WriteShort(5);
                }
            }
            else
            {
                if (User.GetClient() == null || User.GetClient().GetHabbo() == null)
                {
                    base.WriteInteger(0);
                    base.WriteString("");
                    base.WriteString("");
                    base.WriteString("");
                    base.WriteInteger(User.VirtualId);
                    base.WriteInteger(User.X);
                    base.WriteInteger(User.Y);
                    base.WriteString(TextHandling.GetString(User.Z));
                    base.WriteInteger(0);
                    base.WriteInteger(1);
                    base.WriteString("M");
                    base.WriteInteger(0);
                    base.WriteInteger(0);
                    base.WriteString("");

                    base.WriteString("");//Whats this?
                    base.WriteInteger(0);
                    base.WriteBoolean(false);
                }
                else
                {
                    Habbo Habbo = User.GetClient().GetHabbo();

                    Group Group = null;
                    if (Habbo != null)
                    {
                        if (Habbo.FavouriteGroupId > 0)
                        {
                            if (!ButterflyEnvironment.GetGame().GetGroupManager().TryGetGroup(Habbo.FavouriteGroupId, out Group))
                                Group = null;
                        }
                    }

                    if (User.transfbot)
                    {
                        base.WriteInteger(Habbo.Id);
                        base.WriteString(Habbo.Username);
                        base.WriteString("Beep beep.");
                        base.WriteString(Habbo.Look);
                        base.WriteInteger(User.VirtualId);
                        base.WriteInteger(User.X);
                        base.WriteInteger(User.Y);
                        base.WriteString(TextHandling.GetString(User.Z));
                        base.WriteInteger(0);
                        base.WriteInteger(4);

                        base.WriteString(Habbo.Gender);
                        base.WriteInteger(Habbo.Id);
                        base.WriteString(Habbo.Username);
                        base.WriteInteger(0);
                    }
                    else if (User.transformation)
                    {
                        base.WriteInteger(Habbo.Id);
                        base.WriteString(Habbo.Username);
                        base.WriteString(Habbo.Motto);
                        base.WriteString(User.transformationrace + " 2 2 -1 0 3 4 -1 0");

                        base.WriteInteger(User.VirtualId);
                        base.WriteInteger(User.X);
                        base.WriteInteger(User.Y);
                        base.WriteString(TextHandling.GetString(User.Z));
                        base.WriteInteger(4);
                        base.WriteInteger(2);
                        base.WriteInteger(0);
                        base.WriteInteger(Habbo.Id);
                        base.WriteString(Habbo.Username);
                        base.WriteInteger(1);
                        base.WriteBoolean(false);
                        base.WriteBoolean(false);
                        base.WriteInteger(0);
                        base.WriteInteger(0);
                        base.WriteString("");
                    }
                    else
                    {
                        base.WriteInteger(Habbo.Id);
                        base.WriteString(Habbo.Username);
                        base.WriteString(Habbo.Motto);
                        base.WriteString(Habbo.Look);
                        base.WriteInteger(User.VirtualId);
                        base.WriteInteger(User.X);
                        base.WriteInteger(User.Y);
                        base.WriteString(TextHandling.GetString(User.Z));
                        base.WriteInteger(0);
                        base.WriteInteger(1);
                        base.WriteString(Habbo.Gender.ToLower());

                        if (Group != null)
                        {
                            base.WriteInteger(Group.Id);
                            base.WriteInteger(0);
                            base.WriteString(Group.Name);
                        }
                        else
                        {
                            base.WriteInteger(0);
                            base.WriteInteger(0);
                            base.WriteString("");
                        }

                        base.WriteString("");//Whats this?
                        base.WriteInteger(Habbo.AchievementPoints);
                        base.WriteBoolean(false);
                    }
                }
            }
        }
    }
}
