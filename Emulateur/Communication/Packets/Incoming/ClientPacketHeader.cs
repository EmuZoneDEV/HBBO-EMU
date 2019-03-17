namespace Butterfly.Communication.Packets
{
    public static class ClientPacketHeader  //PRODUCTION-201705012204-567246680
    {
        public const int BuyPhotoMessageEvent = 3227;
        public const int ScrGetUserInfoMessageEvent = 1846;
        public const int GetCreditsInfoMessageEvent = 2978;
        public const int SetChatPreferenceMessageEvent = 624;
        public const int SetUserFocusPreferenceEvent = 3919;
        public const int SetMessengerInviteStatusMessageEvent = 1584;
        public const int GetHabboGroupBadgesMessageEvent = 1656;
        public const int GetUserTagsMessageEvent = 3339;

        public const int FindRandomFriendingRoomMessageEvent = 1574;
        public const int NavigatorSearchMessageEvent = 267;
        public const int InitializeNewNavigatorMessageEvent = 1429;


        // Handshake
        public const int GetClientVersionMessageEvent = 4000;
        public const int InitCryptoMessageEvent = 2206;
        public const int GenerateSecretKeyMessageEvent = 3744;
        public const int UniqueIDMessageEvent = 2819;
        public const int SSOTicketMessageEvent = 1461;
        public const int InfoRetrieveMessageEvent = 232;

        public const int GetHelperToolConfiguration = 1039;

        public const int RoomNuxAlert = 1345;

        public const int OnGuideSessionDetached = 647;
        public const int OnGuide = 1268;
        public const int RecomendHelpers = 607;
        public const int GuideToolMessageNew = 2915;
        public const int GuideInviteToRoom = 3260;
        public const int VisitRoomGuides = 2282;
        public const int GuideEndSession = 653;
        public const int CancellInviteGuide = 1724;

        public const int RefreshCampaignMessageEvent = 3612;
        public const int GetPromoArticlesMessageEvent = 2781;
        public const int SaveFloorPlanModelMessageEvent = 218;
        public const int InitializeFloorPlanSessionMessageEvent = 2749;
        public const int UpdateMagicTileMessageEvent = 1301;
        public const int SetSoundSettingsMessageEvent = 553;
        public const int GetRelationshipsMessageEvent = 1453;
        public const int SetRelationshipMessageEvent = 1525;

        public const int GetCatalogOfferMessageEvent = 2466;

        public const int GetRoomEntryDataMessageEvent = 1889;
        public const int GetFurnitureAliasesMessageEvent = 3007;
        public const int GetGuestRoomMessageEvent = 2191;
        public const int LatencyTestMessageEvent = 1395;
        public const int SetFriendBarStateMessageEvent = 148;
        public const int CheckReleaseMessageEvent = 4000;
        public const int GetUserFlatCatsMessageEvent = 3210;
        public const int PingMessageEvent = 3294;
        public const int OpenHelpToolMessageEvent = 318;

        public const int GetWardrobeMessageEvent = 1787;
        public const int SaveWardrobeOutfitMessageEvent = 1346;

        public const int GetAchievementsMessageEvent = 3742;

        public const int GetCatalogIndexMessageEvent = 1970;
        public const int GetCatalogPageMessageEvent = 85;
        public const int GetSellablePetBreedsMessageEvent = 1549;

        public const int CheckPetNameMessageEvent = 3779;
        public const int GetGiftWrappingConfigurationMessageEvent = 776;
        public const int PurchaseFromCatalogMessageEvent = 997;
        public const int PurchaseFromCatalogAsGiftMessageEvent = 451;
        public const int OpenGiftMessageEvent = 1833;
        public const int GetGroupFurniSettingsMessageEvent = 153;
        public const int ConfirmLoveLockMessageEvent = 1674;
        public const int AvatarEffectSelectedMessageEvent = 636;
        public const int AvatarEffectActivatedMessageEvent = 644;
        public const int RedeemVoucherMessageEvent = 3655;
        
        public const int CanCreateRoomMessageEvent = 1890;
        public const int CreateFlatMessageEvent = 1671;

        public const int GetRoomSettingsMessageEvent = 1428;

        public const int SaveRoomSettingsMessageEvent = 2751;
        public const int OpenFlatConnectionMessageEvent = 3631;
        public const int GoToFlatMessageEvent = 497;

        public const int LookToMessageEvent = 965;

        public const int InitTradeMessageEvent = 2698;

        public const int TradingOfferItemsMessageEvent = 2281;
        public const int TradingOfferItemMessageEvent = 2618;
        public const int TradingRemoveItemMessageEvent = 2992;
        public const int TradingAcceptMessageEvent = 742;
        public const int TradingModifyMessageEvent = 2585;
        public const int TradingCancelMessageEvent = 2849;
        public const int TradingConfirmMessageEvent = 340;
        public const int TradingCancelConfirmMessageEvent = 3552;

        public const int MoveAvatarMessageEvent = 3711;

        public const int ChatMessageEvent = 2050;
        public const int ShoutMessageEvent = 3044;
        public const int WhisperMessageEvent = 1445;

        public const int RespectUserMessageEvent = 3036;
        public const int UpdateFigureDataMessageEvent = 1717;
        public const int ChangeMottoMessageEvent = 2889;
        public const int SitMessageEvent = 989;
        public const int DanceMessageEvent = 3616;
        public const int ApplySignMessageEvent = 1084;
        public const int ActionMessageEvent = 3923;

        public const int GetBuddyRequestsMessageEvent = 3230;
        public const int MessengerInitMessageEvent = 700;
        public const int RequestBuddyMessageEvent = 2025;
        public const int AcceptBuddyMessageEvent = 1685;
        public const int DeclineBuddyMessageEvent = 3330;
        public const int SendMsgMessageEvent = 2465;
        public const int FollowFriendMessageEvent = 1867;
        public const int SendRoomInviteMessageEvent = 1967;
        public const int HabboSearchMessageEvent = 3588;
        public const int RemoveBuddyMessageEvent = 1361;

        public const int OpenPlayerProfileMessageEvent = 576;

        public const int RequestFurniInventoryMessageEvent = 1790;
        public const int GetPetInventoryMessageEvent = 1610;
        public const int GetBadgesMessageEvent = 3148;
        public const int GetBotInventoryMessageEvent = 1424;

        public const int PlacePetMessageEvent = 172;
        public const int PickUpPetMessageEvent = 3805;
        public const int RespectPetMessageEvent = 2078;
        public const int GetPetInformationMessageEvent = 2549;
        public const int MoveMonsterPlanteMessageEvent = 3653;
        public const int GetPetTrainingPanelMessageEvent = 995;

        public const int ApplyHorseEffectMessageEvent = 264;
        public const int RemoveSaddleFromHorseMessageEvent = 1077;
        public const int RideHorseMessageEvent = 3911;
        public const int ModifyWhoCanRideHorseMessageEvent = 3902;

        public const int ApplyDecorationMessageEvent = 992;
        public const int PlaceObjectMessageEvent = 2334;
        public const int MoveObjectMessageEvent = 1478;
        public const int MoveWallItemMessageEvent = 1651;
        public const int UseFurnitureMessageEvent = 3299;
        public const int SetTonerMessageEvent = 110;
        public const int UseWallItemMessageEvent = 3291;
        public const int UseHabboWheelMessageEvent = 2339;
        public const int UseOneWayGateMessageEvent = 3027;
        public const int GetMoodlightConfigMessageEvent = 2543;
        public const int ToggleMoodlightMessageEvent = 3398;
        public const int MoodlightUpdateMessageEvent = 1989;
        public const int AddStickyNoteMessageEvent = 565;
        public const int GetStickyNoteMessageEvent = 2883;
        public const int UpdateStickyNoteMessageEvent = 1297;
        public const int DeleteStickyNoteMessageEvent = 2115;

        public const int UpdateNavigatorSettingsMessageEvent = 2144;
        public const int DeleteRoomMessageEvent = 876;

        public const int CreditFurniRedeemMessageEvent = 3056;

        public const int StartTypingMessageEvent = 1755;
        public const int CancelTypingMessageEvent = 1580;

        public const int AssignRightsMessageEvent = 2731;
        public const int GetRoomRightsMessageEvent = 1514;
        public const int GetRoomBannedUsersMessageEvent = 1716;
        public const int UnbanUserFromRoomMessageEvent = 817;
        public const int RemoveAllRightsMessageEvent = 1788;
        public const int RemoveRightsMessageEvent = 2194;
        public const int RemoveMyRightsMessageEvent = 2530;

        public const int PickupObjectMessageEvent = 2235;

        public const int SaveWiredTriggerConfigMessageEvent = 1490;
        public const int SaveWiredEffectConfigMessageEvent = 1150;
        public const int SaveWiredConditionConfigMessageEvent = 582;

        public const int GetModeratorRoomInfoMessageEvent = 1602;
        public const int GetModeratorUserInfoMessageEvent = 3542;
        public const int GetModeratorUserRoomVisitsMessageEvent = 3272;
        public const int GetModeratorUserChatlogMessageEvent = 759;
        public const int ModerationKickMessageEvent = 3143;
        public const int ModerationMuteMessageEvent = 2493;
        public const int ModerationBanMessageEvent = 1480;
        public const int ModerationMsgMessageEvent = 2468;
        public const int ModerationCautionMessageEvent = 206;
        public const int SubmitNewTicketMessageEvent = 1335;
        public const int PickTicketMessageEvent = 1330;
        public const int CloseTicketMesageEvent = 186;
        public const int ReleaseTicketMessageEvent = 2303;
        public const int ModerateRoomMessageEvent = 1397;
        public const int GetModeratorRoomChatlogMessageEvent = 2578;

        public const int GiveRoomScoreMessageEvent = 57;

        public const int ModeratorActionMessageEvent = 3521;
        public const int KickUserMessageEvent = 874;
        public const int BanUserMessageEvent = 2232;
        public const int MuteUserMessageEvent = 1357;
        public const int ToggleMuteToolMessageEvent = 282;
        public const int IgnoreUserMessageEvent = 2640;
        public const int UnIgnoreUserMessageEvent = 3964;
        public const int LetUserInMessageEvent = 1605;
        public const int AddFavouriteRoomMessageEvent = 1383;
        public const int DeleteFavouriteRoomMessageEvent = 1500;
        public const int SetActivatedBadgesMessageEvent = 915;
        public const int GetSelectedBadgesMessageEvent = 954;
        public const int GoToHotelViewMessageEvent = 2918;

        public const int DropHandItemMessageEvent = 3757;
        public const int GiveHandItemMessageEvent = 698;

        public const int ThrowDiceMessageEvent = 447;
        public const int DiceOffMessageEvent = 3810;

        public const int GetQuestListMessageEvent = 3468;
        public const int StartQuestMessageEvent = 3822;
        public const int CancelQuestMessageEvent = 1233;
        public const int GetCurrentQuestMessageEvent = 2234;

        public const int OnBullyClickMessageEvent = 3604;
        public const int SendBullyReportMessageEvent = 2256;
        public const int SubmitBullyReportMessageEvent = 3962;
        public const int GetSanctionStatusMessageEvent = 1027;

        public const int CheckValidNameMessageEvent = 1756;
        public const int ChangeNameMessageEvent = 3465;
        public const int SetMannequinNameMessageEvent = 1109;
        public const int SetMannequinFigureMessageEvent = 2813;
        public const int GetGroupCreationWindowMessageEvent = 2453;
        public const int PurchaseGroupMessageEvent = 3071;
        public const int ManageGroupMessageEvent = 217;
        public const int GetBadgeEditorPartsMessageEvent = 1962;
        public const int UpdateGroupIdentityMessageEvent = 209;
        public const int UpdateGroupBadgeMessageEvent = 357;
        public const int UpdateGroupColoursMessageEvent = 235;
        public const int UpdateGroupSettingsMessageEvent = 583;
        public const int GetGroupMembersMessageEvent = 3310;
        public const int JoinGroupMessageEvent = 1126;
        public const int DeclineGroupMembershipMessageEvent = 3938;
        public const int DeleteGroupMessageEvent = 1984;
        public const int AcceptGroupMembershipMessageEvent = 2292;
        public const int RemoveGroupFavouriteMessageEvent = 2641;
        public const int SetGroupFavouriteMessageEvent = 230;
        public const int GiveAdminRightsMessageEvent = 306;
        public const int TakeAdminRightsMessageEvent = 585;
        public const int GetGroupFurniConfigMessageEvent = 1105;
        public const int GetGroupInfoMessageEvent = 1802;
        public const int RemoveGroupMemberMessageEvent = 837;
        public const int PlaceBotMessageEvent = 1888;
        public const int PickUpBotMessageEvent = 1783;
        public const int OpenBotActionMessageEvent = 1083;
        public const int SaveBotActionMessageEvent = 1859;
        public const int SaveBrandingItemMessageEvent = 277;
        public const int ChangeFootGate = 1683;
        public const int FindNewFriendsMessageEvent = 1005;
        public const int FriendListUpdateMessageEvent = 2535;

        public const int GetOffersMessageEvent = 3407;
        public const int GetOwnOffersMessageEvent = 3328;
        public const int GetMarketplaceCanMakeOfferMessageEvent = 1977;
        public const int GetMarketplaceItemStatsMessageEvent = 3130;
        public const int MakeOfferMessageEvent = 881;
        public const int CancelOfferMessageEvent = 1498;
        public const int BuyOfferMessageEvent = 3476;
        public const int RedeemOfferCreditsMessageEvent = 1151;
        public const int GetMarketplaceConfigurationMessageEvent = 1901;
    }
}
